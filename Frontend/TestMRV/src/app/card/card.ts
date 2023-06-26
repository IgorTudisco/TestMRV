export class Card {

  FirstName: string;
  Suburb: string;
  Category: string;
  Description: string;
  Price: number;

  constructor(firstName: string, suburb: string, category: string, description: string, price: number) {
    this.FirstName = firstName;
    this.Suburb = suburb;
    this.Category = category;
    this.Description = description;
    this.Price = price;
  }
}
