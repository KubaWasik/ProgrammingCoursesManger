import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
})
export class NavMenuComponent {
  constructor(private router: Router) {}

  public async openHomePage(): Promise<void> {
    await this.router.navigateByUrl('/');
  }
}
