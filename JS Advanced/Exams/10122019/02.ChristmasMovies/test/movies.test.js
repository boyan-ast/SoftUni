const ChristmasMovies = require('../movies');
const { assert } = require('chai');

describe('test christmas movies', () => {
    describe('test constructor', () => {
        it('should initialize collections', () => {
            let movies = new ChristmasMovies();

            assert.deepEqual(movies.movieCollection, []);
            assert.deepEqual(movies.watched, {});
            assert.deepEqual(movies.actors, []);
        });
    });
    describe('test buyMovie', () => {
        it('should return correct result with unique actors and new movie', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();

            let expected = `You just got ${movieName} to your collection in which ${[...new Set(actors)].join(', ')} are taking part!`;

            assert.equal(movies.buyMovie(movieName, actors), expected);
        });
        it('should increase movieCollection count when successfully added', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);

            assert.equal(movies.movieCollection.length, 1);
        });
        it('should throw if the movie exists', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);

            assert.throw(() => movies.buyMovie(movieName, []));
        });
    });
    describe('test discardMovie', () => {
        it('should throw if non existing movie', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);
            movies.buyMovie('Test', ['Joe Dickson']);

            assert.throw(() => movies.discardMovie('Shame'));
        });
        it('should return correct when the movies is existing and watched', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);
            movies.watchMovie(movieName);

            let expected = `You just threw away ${movieName}!`;

            assert.equal(movies.discardMovie(movieName), expected);
            assert.isFalse(movies.watched.hasOwnProperty(movieName));
        });
        it('should return remove movie from collection when exists', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);
            movies.watchMovie(movieName);

            assert.isUndefined(movies.movieCollection.find(m => m.movieName == movieName));
        });
        it('should throw when movie exists but is not watched', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);

            assert.Throw(() => movies.discardMovie(movieName));
        });
    });
    describe('test watchMovie', () => {
        it('should throw when the movie is not in the collection', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);

            assert.Throw(() => movies.watchMovie('New'), 'No such movie in your collection!');
        });
        it('should initialize property in watched when it is first time', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);
            movies.watchMovie(movieName);

            assert.equal(movies.watched[movieName], 1);
        });
        it('should increase count when watched more times', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);
            movies.buyMovie('Second', []);
            
            movies.watchMovie(movieName);
            movies.watchMovie(movieName);
            movies.watchMovie(movieName);

            assert.equal(movies.watched[movieName], 3);
            assert.isFalse(movies.watched.hasOwnProperty('Second'));
        });
    });
    describe('test favouriteMovie', () => {
        it('should return correct result when there are watched movies', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);
            movies.buyMovie('Second', []);
            movies.buyMovie('Third', []);
            
            movies.watchMovie(movieName);
            movies.watchMovie(movieName);
            movies.watchMovie('Second');
            movies.watchMovie('Third');

            let expected = `Your favourite movie is ${movieName} and you have watched it 2 times!`;

            assert.equal(movies.favouriteMovie(), expected);
        });
        it('should return first movie when the watch count is equal', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);
            movies.buyMovie('Second', []);
            movies.buyMovie('Third', []);            

            movies.watchMovie('Second');
            movies.watchMovie(movieName);
            movies.watchMovie('Third');

            let expected = `Your favourite movie is Second and you have watched it 1 times!`;

            assert.equal(movies.favouriteMovie(), expected);
        });
        it('should throw when there are no watched movies', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);
            movies.buyMovie('Second', []);
            movies.buyMovie('Third', []);

            assert.throw(() => movies.favouriteMovie());
        });
    });
    describe('test mostStarredActor', () => {
        it('should throw when there are no movies', () => {
            let movies = new ChristmasMovies();
            
            assert.throw(() => movies.mostStarredActor());            
        });

        it('should return correct actor when there are movies', () => {
            let movieName = 'Home Alone';
            let actors = ['Macaulay Culkin', 'Joe Pesci', 'Daniel Stern'];

            let movies = new ChristmasMovies();
            movies.buyMovie(movieName, actors);
            movies.buyMovie('Second', ['Macaulay Culkin']);
            movies.buyMovie('Third', ['Macaulay Culkin']);

            let expected = `The most starred actor is Macaulay Culkin and starred in 3 movies!`;

            assert.equal(movies.mostStarredActor(), expected);
        });
    });
});