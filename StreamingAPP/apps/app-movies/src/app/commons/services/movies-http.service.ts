import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'apps/app-movies/src/environments/environment';
import {
  MovieResponseDTO,
  GenresResponseDTO,
} from '../interfaces/movies.interface';

@Injectable({
  providedIn: 'root',
})
export class MoviesHttpService {
  urlMovies: string = environment.urlMovies;
  key: string = environment.apiKey;
  language = 'es';

  constructor(private http: HttpClient) {}

  getAllByYear(year?: string) {
    year = year ? year : new Date().getFullYear.toString();
    return this.http.get<MovieResponseDTO>(
      `${this.urlMovies}/discover/movie?api_key=${this.key}&language=${this.language}&primary_release_year=${year}&include_image_language=${this.language}`
    );
  }
  getByFilters(year:number) {

      return this.http.get<MovieResponseDTO>(
        `${this.urlMovies}/discover/movie?api_key=${this.key}&language=${this.language}&year=${year}&include_image_language=${this.language}`
      );
    // }
    // else{

    //   return this.http.get<MovieResponseDTO>(
    //     `${this.urlMovies}/discover/movie?api_key=${this.key}&language=${this.language}&include_image_language=${this.language}&release_date.gte=${this.start}`
    //   );
    // }

  }
  getAllGenres() {
    return this.http.get<GenresResponseDTO>(
      `${this.urlMovies}/genre/movie/list?api_key=${this.key}&language=${this.language}`
    );
  }
}
