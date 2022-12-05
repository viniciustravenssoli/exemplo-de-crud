import { MatSnackBar } from '@angular/material/snack-bar';
import { Jogo } from 'src/app/models/jogo.model';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-palpitar-jogo",
  templateUrl: "./palpitar-jogo.component.html",
  styleUrls: ["./palpitar-jogo.component.css"],
})
export class PalpitarJogoComponent implements OnInit {
  
  id!: number;
  jogo!: Jogo;
  selecaoA!: string;
  selecaoB!: string;
  placarA!: number;
  placarB!: number;


  constructor(private http : HttpClient, private router : Router, private route : ActivatedRoute, private _snackBar :MatSnackBar) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      let { id } = params;
      if ( id !== undefined) {
        this.id = id;
        this.http.get<Jogo>(`https://localhost:5001/api/jogo/buscar/${id}`).subscribe({
          next: (jogo) => {
            this.selecaoA = jogo.selecaoA?.nome!;
            this.selecaoB = jogo.selecaoB?.nome!;
            this.placarA = jogo.placarA!;
            this.placarB = jogo.placarB!;
            this.jogo = jogo;
          }
        })
      }
    })
  }
  
  cadastrar(): void {
    this.jogo.placarA = this.placarA;
    this.jogo.placarB = this.placarB;

    this.http
      .put<Jogo>("https://localhost:5001/api/jogo/alterar", this.jogo)
      .subscribe({
        next: (jogo) => {
          this._snackBar.open("Palpite cadastrado!", "Ok!", {
            horizontalPosition: "right",
            verticalPosition: "top",
          });
          this.router.navigate(["pages/jogo/listar"]);
        },
        error: (error) => {
          console.error("Algum erro aconteceu!", error);
        },
      });
  }
}

