/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { RestaurantViewIEnumerableResponse } from '../models/restaurant-view-i-enumerable-response';

@Injectable({
  providedIn: 'root',
})
export class RestaurantService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiRestaurantTicketGet
   */
  static readonly ApiRestaurantTicketGetPath = '/api/restaurant/{ticket}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiRestaurantTicketGet()` instead.
   *
   * This method doesn't expect any response body
   */
  apiRestaurantTicketGet$Response(params: {
    ticket: string;

  }): Observable<StrictHttpResponse<RestaurantViewIEnumerableResponse>> {

    const rb = new RequestBuilder(this.rootUrl, RestaurantService.ApiRestaurantTicketGetPath, 'get');
    if (params) {

      rb.path('ticket', params.ticket);

    }
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<RestaurantViewIEnumerableResponse>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiRestaurantTicketGet$Response()` instead.
   *
   * This method doesn't expect any response body
   */
  apiRestaurantTicketGet(params: {
    ticket: string;

  }): Observable<RestaurantViewIEnumerableResponse> {

    return this.apiRestaurantTicketGet$Response(params).pipe(
      map((r: StrictHttpResponse<RestaurantViewIEnumerableResponse>) => r.body as RestaurantViewIEnumerableResponse)
    );
  }

}
