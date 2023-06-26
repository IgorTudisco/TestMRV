import { Component, OnInit } from '@angular/core';
import { Card } from './card';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  title = "Card de vendas"
  ArrayCard: Card[] = [
    new Card("Tainá", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 333.0),
    new Card("Tainá", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 333.0),
    new Card("Tainá", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 333.0),
    new Card("Tainá", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 333.0),
  ];

}
