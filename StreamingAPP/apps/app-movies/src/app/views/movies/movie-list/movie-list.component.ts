import { Component, OnInit, ChangeDetectionStrategy, Input, SimpleChanges } from '@angular/core';
import { MoviesHttpService } from '../../../commons/services/movies-http.service';
import { MovieResponseDTO, Movie, GenresResponseDTO } from '../../../commons/interfaces/movies.interface';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class MovieListComponent implements OnInit {
  @Input() nameMovie: string;
  @Input() yearRealease:number;
  @Input() dateStart:Date;
  @Input() dateEnd:Date;

  responseMovie: MovieResponseDTO;
  movies: Movie[];
  responseGenres: GenresResponseDTO;
  mapGenres:string[];

  constructor(private movieService: MoviesHttpService) { }

  ngOnInit(): void {
    // this.movieService.getAllGenres().subscribe((genres) => {
    //   this.responseGenres = genres;
    // });
    // this.movieService.getAllByYear(this.yearRealease).subscribe((movies) => {
    //   this.responseMovie = movies;
    //   console.log('Response Component', this.responseMovie);
    //   this.movies = this.responseMovie.results;
    //   var result = new Map(this.responseGenres.genres.map(key => [key.id, key.name]));
    //   this.movies.forEach( m => m.genre_description = m.genre_ids.map((ids)=>result.get(ids)));
    //   console.log('Movies Component', this.movies);
    // });
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log(this.yearRealease,'year')
    this.movieService.getAllGenres().subscribe((genres) => {
      this.responseGenres = genres;
    });
    this.movieService.getByFilters(this.yearRealease).subscribe((movies) => {
      this.responseMovie = movies;
      this.movies = this.responseMovie.results;
      var result = new Map(this.responseGenres.genres.map(key => [key.id, key.name]));
      this.movies.forEach( m => m.genre_description = m.genre_ids.map((ids)=>result.get(ids)));
      console.log('Movies Component', this.movies);

    });
    }

}
