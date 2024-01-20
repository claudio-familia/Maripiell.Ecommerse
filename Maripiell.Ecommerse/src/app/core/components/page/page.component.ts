import { Component, Input } from '@angular/core';

@Component({
  selector: 'mall-page',
  templateUrl: './page.component.html',
  styleUrls: ['./page.component.scss']
})
export class PageComponent {
  @Input() routeText: string = "";
  @Input() routeTo: string = "";
  @Input() title: string = "";
}
