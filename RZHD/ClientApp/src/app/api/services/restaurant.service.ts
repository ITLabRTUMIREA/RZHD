/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { CreateOrderRequest } from '../models/create-order-request';
import { Int32Response } from '../models/int-32-response';
import { MenuViewIEnumerableResponse } from '../models/menu-view-i-enumerable-response';
import { OrderViewResponse } from '../models/order-view-response';
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

  /**
   * Path part for operation apiRestaurantRestIdGet
   */
  static readonly ApiRestaurantRestIdGetPath = '/api/restaurant/{restId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiRestaurantRestIdGet()` instead.
   *
   * This method doesn't expect any response body
   */
  apiRestaurantRestIdGet$Response(params: {
    restId: number;

  }): Observable<StrictHttpResponse<MenuViewIEnumerableResponse>> {

    const rb = new RequestBuilder(this.rootUrl, RestaurantService.ApiRestaurantRestIdGetPath, 'get');
    if (params) {

      rb.path('restId', params.restId);

    }
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<MenuViewIEnumerableResponse>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiRestaurantRestIdGet$Response()` instead.
   *
   * This method doesn't expect any response body
   */
  apiRestaurantRestIdGet(params: {
    restId: number;

  }): Observable<MenuViewIEnumerableResponse> {

    return this.apiRestaurantRestIdGet$Response(params).pipe(
      map((r: StrictHttpResponse<MenuViewIEnumerableResponse>) => r.body as MenuViewIEnumerableResponse)
    );
  }

  /**
   * Path part for operation apiRestaurantAdminPost
   */
  static readonly ApiRestaurantAdminPostPath = '/api/restaurant/admin';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiRestaurantAdminPost$Json()` instead.
   *
   * This method sends `application/json-patch+json` and handles response body of type `application/json-patch+json`
   */
  apiRestaurantAdminPost$Json$Response(params?: {

    body?: CreateOrderRequest
  }): Observable<StrictHttpResponse<Int32Response>> {

    const rb = new RequestBuilder(this.rootUrl, RestaurantService.ApiRestaurantAdminPostPath, 'post');
    if (params) {


      rb.body(params.body, 'application/json-patch+json');
    }
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Int32Response>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiRestaurantAdminPost$Json$Response()` instead.
   *
   * This method sends `application/json-patch+json` and handles response body of type `application/json-patch+json`
   */
  apiRestaurantAdminPost$Json(params?: {

    body?: CreateOrderRequest
  }): Observable<Int32Response> {

    return this.apiRestaurantAdminPost$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Int32Response>) => r.body as Int32Response)
    );
  }

<<<<<<< Updated upstream
  /**
   * Path part for operation apiRestaurantAdimnOrderIdGet
   */
  static readonly ApiRestaurantAdimnOrderIdGetPath = '/api/restaurant/adimn/{orderId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiRestaurantAdimnOrderIdGet()` instead.
   *
   * This method doesn't expect any response body
   */
  apiRestaurantAdimnOrderIdGet$Response(params: {
    orderId: number;

  }): Observable<StrictHttpResponse<OrderViewResponse>> {

    const rb = new RequestBuilder(this.rootUrl, RestaurantService.ApiRestaurantAdimnOrderIdGetPath, 'get');
    if (params) {

      rb.path('orderId', params.orderId);

    }
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<OrderViewResponse>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiRestaurantAdimnOrderIdGet$Response()` instead.
   *
   * This method doesn't expect any response body
   */
  apiRestaurantAdimnOrderIdGet(params: {
    orderId: number;

  }): Observable<OrderViewResponse> {

    return this.apiRestaurantAdimnOrderIdGet$Response(params).pipe(
      map((r: StrictHttpResponse<OrderViewResponse>) => r.body as OrderViewResponse)
    );
  }

=======
>>>>>>> Stashed changes
}
