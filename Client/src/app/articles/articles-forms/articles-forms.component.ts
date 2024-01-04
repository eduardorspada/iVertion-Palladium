import { Component, OnInit} from '@angular/core';
import { Article } from '../article';
import { ArticlesService } from 'src/app/articles.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-articles-forms',
  templateUrl: './articles-forms.component.html',
  styleUrls: ['./articles-forms.component.scss']
})
export class ArticlesFormsComponent implements OnInit {

  article: Article;
  roles: Array<string>;
  role: string = 'AddArticle'

  options: Object = {
    placeholderText: 'Insira seu conteúdo ...',
    charCounterCount: true,
    theme: "dark",
    toolbarBottom: false,
    toolbarButtons: ['bold', 'italic', 'textColor', 'backgroundColor'],
    // Colors list.
    colorsBackground: [
      '#15E67F', '#E3DE8C', '#D8A076', '#D83762', '#76B6D8', 'REMOVE',
      '#1C7A90', '#249CB8', '#4ABED9', '#FBD75B', '#FBE571', '#FFFFFF'
    ],
    colorsStep: 6,
    colorsText: [
      '#15E67F', '#E3DE8C', '#D8A076', '#D83762', '#76B6D8', 'REMOVE',
      '#1C7A90', '#249CB8', '#4ABED9', '#FBD75B', '#FBE571', '#FFFFFF'
    ]
  }
  constructor(private router: Router, private service: ArticlesService, private authService: AuthService) {

    this.article = service.getArticle()
    this.roles = authService.getRoles();
  
  }
  ngOnInit(): void {
    if (this.roles.indexOf(this.role) === -1) {
      this.router.navigate(['manager/403'])
    }
  }
  onSubmit(){
    this.service.createArticle(this.article).subscribe((response: any) => {
      console.log(response);
    });
  }
}
