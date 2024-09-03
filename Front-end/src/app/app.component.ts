import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient, provideHttpClient } from '@angular/common/http';
import { Professor } from './models/professor';
import { CommonModule, NgFor } from '@angular/common';
import { Observable } from 'rxjs';
import {
  FormsModule,
  ReactiveFormsModule,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ProfessorDto } from './models/professorDto';
import { NgxMaskDirective, provideNgxMask } from 'ngx-mask';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    CommonModule,
    NgFor,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskDirective,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  providers: [provideNgxMask()],
})
export class AppComponent implements OnInit {
  title = 'AplicacaoTeste';
  http = inject(HttpClient);
  fb = inject(FormBuilder);
  urlApi = 'https://localhost:7130/';
  professores$?: Observable<Professor[]>;
  professorEncontrado$?: Observable<Professor>;
  valorBusca = '';

  // FormGroup para adicionar professor
  professorForm: FormGroup;

  constructor() {
    // Inicializa o FormGroup com validações
    this.professorForm = this.fb.group({
      nome: ['', Validators.required],
      cpf: [
        '',
        [
          Validators.required,
          Validators.pattern(/^\d{3}\.\d{3}\.\d{3}-\d{2}$/),
        ],
      ],
      email: ['', [Validators.required, Validators.email]],
      telefone: [
        '',
        [Validators.required, Validators.pattern(/^\(\d{2}\) \d{5}-\d{4}$/)],
      ],
      materia: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.obterProfessores();
  }

  obterProfessores() {
    this.professores$ = this.http.get<Professor[]>(
      `${this.urlApi}api/Professor`
    );
  }

  buscarPorNome() {
    if (!this.valorBusca) return;

    this.professorEncontrado$ = this.http.get<Professor>(
      `${this.urlApi}api/Professor/${this.valorBusca}`
    );
  }

  addProfessor() {
    if (this.professorForm.invalid) {
      this.professorForm.markAllAsTouched();
      return;
    }

    const professor: ProfessorDto = this.professorForm.value;

    this.http
      .post<void>(`${this.urlApi}api/Professor`, professor)
      .subscribe(() => {
        this.obterProfessores();
        this.professorForm.reset(); // Reseta o formulário após adicionar
      });
  }
}
