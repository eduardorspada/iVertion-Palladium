import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.scss']
})
export class ManagerComponent implements OnInit {
  constructor(@Inject(DOCUMENT) private document: Document){
    
  }

  ngOnInit() {
    this.document.body.classList.add('hold-transition', 'dark-mode', 'sidebar-mini', 'layout-fixed', 'layout-navbar-fixed', 'layout-footer-fixed', 'sidebar-collapse')
  }
}
