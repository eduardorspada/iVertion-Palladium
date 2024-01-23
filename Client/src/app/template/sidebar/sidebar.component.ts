import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})

export class SidebarComponent implements OnInit { //terminar
  constructor(
    private authService: AuthService,
    private router: Router,
    @Inject(DOCUMENT) private document: Document
    ) {}


  userName: string = "";
  public roles = this.authService.getRoles();


  private menu = [
      {
        name: "Home",
        iconClasses: ["nav-icon", "fa-solid", "fa-house"],
        path: ["/manager/"],
        event: "",
        type: "single",
        active: true,
        role: "Manager",
        children: []
      },
      {
        name: "Dashboard",
        iconClasses: ["nav-icon", "fas", "fa-tachometer-alt"],
        path: [""],
        event: "",
        type: "root",
        active: false,
        role: "Dashboard",
        children: [
          {
            name: "Administration",
            iconClasses: ["nav-icon", "fas", "fa-tachometer-alt"],
            path: ["/manager/dashboard/admin"],
            event: "",
            type: "children",
            active: false,
            role: "Admin",
          },
          {
            name: "Blogs",
            iconClasses: ["nav-icon", "fas", "fa-tachometer-alt"],
            path: ["/manager/dashboard/blogger"],
            event: "",
            type: "children",
            active: false,
            role: "Blogger",
          },
          {
            name: "Totem",
            iconClasses: ["nav-icon", "fas", "fa-tachometer-alt"],
            path: ["/manager/dashboard/ticketer"],
            event: "",
            type: "children",
            active: false,
            role: "Ticketer",
          },
          {
            name: "Analitics",
            iconClasses: ["nav-icon", "fa-solid", "fa-chart-simple"],
            path: ["/manager/dashboard/analitics"],
            event: "",
            type: "children",
            active: false,
            role: "Traffic",
          },
          {
            name: "Adsense",
            iconClasses: ["nav-icon", "fa-solid", "fa-rectangle-ad",],
            path: ["/manager/dashboard/adsense"],
            event: "",
            type: "children",
            active: false,
            role: "Adsense",
          },
        ]
      },
      {
        name: "Blog",
        iconClasses: ["nav-icon", "fa-solid", "fa-newspaper"],
        path: [""],
        event: "",
        type: "root",
        active: false,
        role: "Blogger",
        children: [
          {
            name: "Artigo",
            iconClasses: ["nav-icon", "fa-solid", "fa-blog"],
            path: ["/manager/article"],
            event: "",
            type: "children",
            active: false,
            role: "ManagerArticles",
          },
          {
            name: "Novo",
            iconClasses: ["nav-icon", "fas", "fa-plus"],
            path: ["/manager/article/form"],
            event: "",
            type: "children",
            active: false,
            role: "AddArticle",
          },
        ]
      },
      {
        name: "Users Administration",
        iconClasses: ["nav-icon", "fa-solid", "fa-user-gear"],
        path: [""],
        event: "",
        type: "root",
        role: "Admin",
        children: [
          {
            name: "Users",
            iconClasses: ["nav-icon", "fa-solid", "fa-users-gear"],
            path: ["/manager/users/list"],
            event: "",
            type: "children",
            active: false,
            role: "GetUsers",
          },
          {
            name: "Users Profiles",
            iconClasses: ["nav-icon", "fa-solid", "fa-person-military-pointing"],
            path: ["/manager/users/users-profile-list"],
            event: "",
            type: "children",
            active: false,
            role: "AddToRole",
          },
          {
            name: "New Users Profiles",
            iconClasses: ["nav-icon", "fa-solid", "fa-folder-plus"],
            path: ["/manager/users/new-user-profile"],
            event: "",
            type: "children",
            active: false,
            role: "AddToRole",
          },
          {
            name: "Novo",
            iconClasses: ["nav-icon", "fa-solid", "fa-user-plus"],
            path: ["/manager/users/form"],
            event: "",
            type: "children",
            active: false,
            role: "AddUser",
          },
        ]
      },

  ]

  public sidebar: any[] = []


  

  ngOnInit(): void {
    this.userName = this.authService.getUserName();


    for (let item of this.menu) {
      let tempMenuItem: any = []
      if (this.roles.indexOf(item.role) !== -1) {
        let tempItem = JSON.parse(JSON.stringify(item));
        tempMenuItem.push(tempItem);
        let index = tempMenuItem.indexOf(tempItem);
        tempMenuItem[index].children = [];
        for (let child of item.children){
          if (this.roles.indexOf(child.role) !== -1) {
            let tempChild = JSON.parse(JSON.stringify(child));
            tempItem.children.push(tempChild);
          }
        }
        this.sidebar.push(tempMenuItem[index]);
      }
    }
  }
  
  
  signOut(){
    this.authService.signOut();
    this.router.navigate(['/login']);
  }
  
  
}
