import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls : ['./home.component.css'],
})
export class HomeComponent {

  public yearsOfLife: YearOfLife[] = [];

  constructor(
    public http: HttpClient, 
    @Inject('BASE_URL') public baseUrl: string) { 
      this.loadLifeCalendar();
    }

  public loadLifeCalendar() {
    this.http.get<LifeCalendar>(this.baseUrl + 'lifecalendar').subscribe(result => {
      this.yearsOfLife = result.yearsOfLife;
    }, error => console.error(error));
  }
}

interface LifeCalendar {
  yearsOfLife: YearOfLife[];
}

interface YearOfLife {
  age: number;
  year: number;
  weeks: Week[];
}

interface Week {
  lived: Boolean;
  date: Date;
}