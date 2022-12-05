import { Jogo } from 'src/app/models/jogo.model';
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-listar-jogo",
  templateUrl: "./listar-jogo.component.html",
  styleUrls: ["./listar-jogo.component.css"],
})
export class ListarJogoComponent implements OnInit {
  constructor(private http: HttpClient) {}

  jogos!: Jogo[]

  ngOnInit(): void {
    this.http.get<Jogo[]>("https://localhost:5001/api/jogo/listar").subscribe({
      next: (jogos) => {
        this.jogos = jogos
      }
    })
  }
}