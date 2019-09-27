import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SampleDataService } from '../api/services';
import { WeatherForecast } from '../api/models';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private service: SampleDataService) {
    http.get<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  async ngOnInit() {
    const result = await this.service.apiSampleDataWeatherForecastsGet$Json$Response().toPromise();
    if (result.ok) {
      this.forecasts = result.body;
    }
    else {
      this.forecasts = [];
    }
  }
}
