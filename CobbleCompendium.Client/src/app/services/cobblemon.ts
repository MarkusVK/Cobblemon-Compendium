import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Cobblemon {
  constructor() {}
  private http = inject(HttpClient);
  private apiURL = environment.apiURL + '/Cobblemon';

  public get(): Observable<any> {
    return this.http.get(this.apiURL);
  }
}
