import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { ReadCard } from '../class/ReadCard';

@Injectable({
  providedIn: 'root'
})
export class CardService {

  private baseUrl = 'https://localhost:7046/card';

  constructor(private httpClient: HttpClient) { }

  postAddCard(): Observable<ReadCard[]> {

    const searchUrl = `${this.baseUrl}/`

    return this.postAddCard();
  }

  getCards(skip: number, take: number): Observable<ReadCard[]> {

    const productUrl = `${this.baseUrl}?skip=${skip}&take=${take}`;

    return this.httpClient.get<ReadCard[]>(productUrl);
  }

  getCardById(id: number): Observable<ReadCard> {

    const productUrl = `${this.baseUrl}/${id}`;

    return this.httpClient.get<ReadCard>(productUrl);
  }

  putCard(id: number): Observable<ReadCard> {

    const productUrl = `${this.baseUrl}/${id}`;

    return this.httpClient.get<ReadCard>(productUrl);
  }

  patchCard(id: number): Observable<ReadCard> {

    const productUrl = `${this.baseUrl}/${id}`;

    return this.httpClient.get<ReadCard>(productUrl);
  }

  deleteCard(id: number): Observable<ReadCard> {

    const productUrl = `${this.baseUrl}/${id}`;

    return this.httpClient.get<ReadCard>(productUrl);
  }

}
