import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public yearsOfLife: YearOfLife[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<LifeCalendar>(baseUrl + 'lifecalendar').subscribe(result => {
      this.yearsOfLife = result.yearsOfLife;
    }, error => console.error(error));
  }
}

interface LifeCalendar {
  yearsOfLife: YearOfLife[];
}

interface YearOfLife {
  age:Number;
  year:Number;
  weeks:Week[];
}

interface Week {
  lived:Boolean;
  date:Date;
}