import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {

  public yearsOfLife: YearOfLife[] = [];
  public date: Date = new Date(1990, 1, 1);
  constructor(
    private route: ActivatedRoute,
    public http: HttpClient,
    @Inject('BASE_URL') public baseUrl: string) {
    this.route.queryParams.subscribe(params => {
      var dateparam = params["date"];
      if (dateparam) {
        this.date = new Date(dateparam);
        this.loadLifeCalendar();
      }
    });
  }

  public loadLifeCalendar() {
    this.http.get<LifeCalendar>(this.baseUrl + 'lifecalendar?date=' + this.date.toISOString()).subscribe(result => {
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