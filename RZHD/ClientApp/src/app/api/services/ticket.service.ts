/* tslint:disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { TicketView } from '../models/ticket-view';

@Injectable({
  providedIn: 'root',
})
export class TicketService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiTicketGet
   */
  static readonly ApiTicketGetPath = '/api/ticket';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiTicketGet()` instead.
   *
   * This method doesn't expect any response body
   */
  apiTicketGet$Response(params?: {
    ticket?: string;

  }): Observable<StrictHttpResponse<TicketView>> {

    const rb = new RequestBuilder(this.rootUrl, TicketService.ApiTicketGetPath, 'get');
    if (params) {

      rb.query('ticket', params.ticket);

    }
    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'application/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<TicketView>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiTicketGet$Response()` instead.
   *
   * This method doesn't expect any response body
   */
  apiTicketGet(params?: {
    ticket?: string;

  }): Observable<TicketView> {

    return this.apiTicketGet$Response(params).pipe(
      map((r: StrictHttpResponse<TicketView>) => r.body as TicketView)
    );
  }

}
