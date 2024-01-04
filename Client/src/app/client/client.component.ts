import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {
  title = 'Client';
  constructor(@Inject(DOCUMENT) private document: Document){
    
  }

  ngOnInit() {
    // this.document.body.classList.add('hold-transition', 'dark-mode', 'sidebar-mini', 'layout-fixed', 'layout-navbar-fixed', 'layout-footer-fixed', 'sidebar-collapse')
  }
}
