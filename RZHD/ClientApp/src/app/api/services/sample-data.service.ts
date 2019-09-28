/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { WeatherForecast } from '../models/weather-forecast';

@Injectable({
  providedIn: 'root',
})
export class SampleDataService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiSampleDataWeatherForecastsGet
   */
  static readonly ApiSampleDataWeatherForecastsGetPath = '/api/SampleData/WeatherForecasts';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiSampleDataWeatherForecastsGet$Plain()` instead.
   *
   * This method doesn't expect any response body
   */
  apiSampleDataWeatherForecastsGet$Plain$Response(params?: {

  }): Observable<StrictHttpResponse<Array<WeatherForecast>>> {

    const rb = new RequestBuilder(this.rootUrl, SampleDataService.ApiSampleDataWeatherForecastsGetPath, 'get');
    if (params) {


    }
    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<WeatherForecast>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiSampleDataWeatherForecastsGet$Plain$Response()` instead.
   *
   * This method doesn't expect any response body
   */
  apiSampleDataWeatherForecastsGet$Plain(params?: {

  }): Observable<Array<WeatherForecast>> {

    return this.apiSampleDataWeatherForecastsGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<WeatherForecast>>) => r.body as Array<WeatherForecast>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiSampleDataWeatherForecastsGet$Json()` instead.
   *
   * This method doesn't expect any response body
   */
  apiSampleDataWeatherForecastsGet$Json$Response(params?: {

  }): Observable<StrictHttpResponse<Array<WeatherForecast>>> {

    const rb = new RequestBuilder(this.rootUrl, SampleDataService.ApiSampleDataWeatherForecastsGetPath, 'get');
    if (params) {


    }
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<WeatherForecast>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiSampleDataWeatherForecastsGet$Json$Response()` instead.
   *
   * This method doesn't expect any response body
   */
  apiSampleDataWeatherForecastsGet$Json(params?: {

  }): Observable<Array<WeatherForecast>> {

    return this.apiSampleDataWeatherForecastsGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<WeatherForecast>>) => r.body as Array<WeatherForecast>)
    );
  }

  /**
   * Path part for operation apiSampleDataFuncGet
   */
  static readonly ApiSampleDataFuncGetPath = '/api/SampleData/Func';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiSampleDataFuncGet()` instead.
   *
   * This method doesn't expect any response body
   */
  apiSampleDataFuncGet$Response(params?: {

  }): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, SampleDataService.ApiSampleDataFuncGetPath, 'get');
    if (params) {


    }
    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiSampleDataFuncGet$Response()` instead.
   *
   * This method doesn't expect any response body
   */
  apiSampleDataFuncGet(params?: {

  }): Observable<void> {

    return this.apiSampleDataFuncGet$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
