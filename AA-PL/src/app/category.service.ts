import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators'


const oAuthConfig:AuthConfig = {
  issuer:'https://accounts.google.com',
  strictDiscoveryDocumentValidation: false,
  redirectUri: window.location.origin,
  clientId: '184910368068-ufof3k7cuimpqe5raggspv0d07cue8as.apps.googleusercontent.com',
  scope: 'openid profile email'
}

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  userEmailId:any;
  userName:string;
  userPhoto:any;

  constructor(private http: HttpClient, private readonly oAuthService:OAuthService) {
       oAuthService.configure(oAuthConfig)
       oAuthService.loadDiscoveryDocument().then( () => {
        oAuthService.tryLoginImplicitFlow().then( () =>{
          if(!oAuthService.hasValidAccessToken()){
            oAuthService.initLoginFlow()
          }else {
            oAuthService.loadUserProfile().then( (userProfile) =>{
  
             localStorage.setItem('lsName', JSON.stringify(userProfile.name));
             localStorage.setItem('lsEmail', JSON.stringify(userProfile.email));
             localStorage.setItem('lsPicture', JSON.stringify(userProfile.picture));
            })
          }
        })
       })
   }
  getAllCategories(): Observable<any> {
    return this.http.get<{data:ICategory[]}>('https://localhost:44370/api/Category/GetAllCategories').pipe(
      map((data)=>data),
    );
  }

  getCategoryById(id): Observable<any> {
    return this.http.get<{data:ICategory}>(`https://localhost:44370/api/Category/GetCategoryById?id=${id}`).pipe(
      map((data)=>data),
    );
  }

  addCategory(category:ICategory): Observable<any> {
    return this.http.post<{data:boolean}>(`https://localhost:44370/api/Category/AddCategory`,category).pipe(
      map((data)=>data),
    );
  }

  deleteCategory(id): Observable<any> {
    return this.http.delete<{data:boolean}>(`https://localhost:44370/api/Category/DeleteCategory`,{ params:{id}}).pipe(
      map((data)=>data),
    );
  }

  updateCategory(category:ICategory): Observable<any> {
    return this.http.put<{data:boolean}>(`https://localhost:44370/api/Category/UpdateCategory`,category).pipe(
      map((data)=>data),
    );
  }
}
export interface ICategory{
   categoryId?: string;
   categoryName?: string;
   products?: [];
}
