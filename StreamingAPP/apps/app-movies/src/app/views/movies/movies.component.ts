import { Component, OnInit, Input } from '@angular/core';
import { MoviesHttpService } from '../../commons/services/movies-http.service';
import {
  MovieResponseDTO,
  Movie,
  GenresResponseDTO,
} from '../../commons/interfaces/movies.interface';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss'],
})
export class MoviesComponent implements OnInit {

  year:number;
  name:string;

  // responseMovie: MovieResponseDTO;
  // movies: Movie[];
  // responseGenres: GenresResponseDTO;
  // mapGenres:string[];
  constructor(private movieService: MoviesHttpService) {}

  ngOnInit(): void {
    // this.movieService.getAllGenres().subscribe((genres) => {
    //   this.responseGenres = genres;
    // });
    // this.movieService.getAllByYear().subscribe((movies) => {
    //   this.responseMovie = movies;
    //   console.log('Response', this.responseMovie);
    //   this.movies = this.responseMovie.results;
    //   var result = new Map(this.responseGenres.genres.map(key => [key.id, key.name]));
    //   //this.mapGenres = this.genres.map((genre) => genre.name );
    //   this.movies.forEach( m => m.genre_description = m.genre_ids.map((ids)=>result.get(ids)));
    //   console.log('Movies', this.movies);
    //   // console.log('Generos', this.responseGenres);
    //   // console.log('Result',result);
    // });
  }
  Filtrar()
  {
    console.log(this.year);
  }
}
