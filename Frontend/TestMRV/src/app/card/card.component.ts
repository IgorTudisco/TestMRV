import { Component, OnInit } from '@angular/core';
import { CardService } from '../services/card.service';
import { ReadCard } from '../class/ReadCard';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {

  readCards?: ReadCard[];
  cardList?: ReadCard[];
  constructor(private cardService: CardService) { }

  ngOnInit(): void {
  }

  title = "Card de vendas"
  ArrayCard: ReadCard[] = [
    new ReadCard("Tainá", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 333.0),
    new ReadCard("Daisy", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 333.0),
    new ReadCard("Geovanna", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 333.0),
    new ReadCard("Yuri", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry.", 333.0),
  ];

  getCards(skip?: number, take?: number) {
    skip = 0;
    take = 100;
    this.cardService.getCards(skip, take).subscribe(
      (data: ReadCard[]) => {
        this.cardList = data;
      }
    )
  }

}
