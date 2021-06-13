import { Component, OnInit } from '@angular/core';
import { MoviesHttpService } from '../commons/services/movies-http.service';
import { MovieResponseDTO, Movie, GenresResponseDTO } from '../commons/interfaces/movies.interface';

@Component({
  selector: 'app-views',
  templateUrl: './views.component.html',
  styleUrls: ['./views.component.scss']
})
export class ViewsComponent implements OnInit {
  // responseMovie: MovieResponseDTO;
  // movies: Movie[];
  // responseGenres: GenresResponseDTO;
  // mapGenres:string[];

  constructor(private movieService: MoviesHttpService) { }

  ngOnInit(): void {
  }
  Filtrar(){
    // this.movieService.getAllGenres().subscribe((genres) => {
    //   this.responseGenres = genres;
    // });
    // this.movieService.getAllByYear("2000").subscribe((movies) => {
    //   this.responseMovie = movies;
    //   console.log('Response', this.responseMovie);
    //   this.movies = this.responseMovie.results;
    //   var result = new Map(this.responseGenres.genres.map(key => [key.id, key.name]));
    //   this.movies.forEach( m => m.genre_description = m.genre_ids.map((ids)=>result.get(ids)));
    // });
  }

}
