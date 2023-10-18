import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})
export class StringEncodingService {
    private baseUrl: string = environment.baseUrl + 'api/';

    constructor(private http: HttpClient) { }

    public encode(text: string) {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');

        let body = JSON.stringify(text);

        return  this.http.post(`${this.baseUrl}encode`, body, {
          headers: headers,
          responseType: 'text',
          reportProgress: true,
          observe: 'events'
        });
    }
}