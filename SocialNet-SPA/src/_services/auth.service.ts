import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseurl = 'http://localhost:5000/api/auth/';

constructor(private http: HttpClient) { }

login(model: any) {
  // Use pipes to filter out the token part from the observable
  return this.http.post(this.baseurl + 'login', model).pipe(
    map((response: any) => {
      const user = response;
      localStorage.setItem('token', user.token);
    })
  );
}

register(model: any) {
  return this.http.post(this.baseurl + 'register', model);
}

}
