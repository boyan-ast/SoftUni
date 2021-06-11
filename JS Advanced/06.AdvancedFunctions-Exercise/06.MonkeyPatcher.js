function solution(command) {
    switch (command) {
        case 'upvote':
            this.upvotes++;
            break;
        case 'downvote':
            this.downvotes++;
            break;
        case 'score':
            let reportUpvotes = this.upvotes;
            let reportDownvotes = this.downvotes;
            
            if (reportDownvotes + reportUpvotes > 50) {
                let maxValue = Math.max(this.upvotes, this.downvotes);

                let addValue = Math.ceil(0.25 * maxValue);
                reportUpvotes += addValue;
                reportDownvotes += addValue;
            }

            let totalScore = reportUpvotes - reportDownvotes;
            let rating = '';

            let positivePercent = this.upvotes / (this.upvotes + this.downvotes) * 100;

            if (this.upvotes + this.downvotes < 10) {
                rating = 'new';
            } else if (positivePercent > 66) {
                rating = 'hot';
            } else if (totalScore >= 0 && (this.upvotes + this.downvotes) > 100) {
                rating = 'controversial';
            } else if (totalScore < 0) {
                rating = 'unpopular';
            } else {
                rating = 'new';
            }   

            return [reportUpvotes, reportDownvotes, totalScore, rating];
        default:
            break;
    }
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

solution.call(post, 'upvote');
solution.call(post, 'downvote');
let score = solution.call(post, 'score'); // [127, 127, 0, 'controversial']
console.log(score);
solution.call(post, 'downvote');       // (executed 50 times)
score = solution.call(post, 'score');
console.log(score);
