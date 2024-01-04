import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Article } from './articles/article';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticlesService {
  apiUrl: string = environment.apiUrl;
  constructor( private http: HttpClient) { }
  createArticle(article: Article) : Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/Articles`, article, 
      {
        headers: {
        'Content-Type': 'application/json'
      },
    })
  }


  getArticle() : Article{

    let article: Article = new Article();

    return article;
  }
}
