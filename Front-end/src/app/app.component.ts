import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient, provideHttpClient } from '@angular/common/http';
import { Professor } from './models/professor';
import { CommonModule, NgFor } from '@angular/common';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { ProfessorDto } from './models/professorDto';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, NgFor, FormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent implements OnInit {
  title = 'AplicacaoTeste';
  http = inject(HttpClient);
  urlApi = 'https://localhost:7130/';
  professores$?: Observable<Professor[]>;
  professorEncontrado$?: Observable<Professor>;
  valorBusca = '';

  //add professor
  professorNome = '';
  professorCpf = '';
  professorEmail = '';
  professorTel = '';
  professorMateria = '';

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
    const professor: ProfessorDto = {
      nome: this.professorNome,
      cpf: this.professorCpf,
      email: this.professorEmail,
      telefone: this.professorTel,
      materia: this.professorMateria,
    };

    this.http
      .post<void>(`${this.urlApi}api/Professor`, professor)
      .subscribe((_) => {
        this.obterProfessores(),
          (this.professorNome = ''),
          (this.professorCpf = ''),
          (this.professorEmail = ''),
          (this.professorTel = ''),
          (this.professorMateria = '');
      });
  }
}
