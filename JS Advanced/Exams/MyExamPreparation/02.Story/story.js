class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length == 0) {
            return `${this.title} has 0 likes`;
        } else {
            let firstUser = this._likes[0];

            if (this._likes.length == 1) {
                return `${firstUser} likes this story!`;
            } else {
                return `${firstUser} and ${this._likes.length - 1} others like this story!`;
            }
        }
    }

    like(username) {
        if (this._likes.includes(username)) {
            throw new Error('You can\'t like the same story twice!');
        }

        if (username == this.creator) {
            throw new Error('You can\'t like your own story!');
        }

        this._likes.push(username);

        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        if (!this._likes.includes(username)) {
            throw new Error('You can\'t dislike this story!');
        }

        this._likes = this._likes.filter(u => u !== username);

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        if (id == undefined || !this._comments.find(c => c.Id == id)) {
            let newComment = {
                Id: this._comments.length + 1,
                Username: username,
                Content: content,
                Replies: []
            }

            this._comments.push(newComment);
            return `${username} commented on ${this.title}`;
        } else {
            let comment = this._comments.find(c => c.Id == id);

            let reply = {
                Id: `${comment.Id}.${comment.Replies.length + 1}`,
                Username: username,
                Content: content
            }

            comment.Replies.push(reply);
            return 'You replied successfully';
        }
    }

    toString(sortingType) {
        if (sortingType == 'asc') {
            this._comments.sort((a, b) => a.Id - b.Id);

            this._comments.forEach(c => {
                c.Replies.sort((a, b) =>
                    Number(a.Id.split('.')[1]) - Number(b.Id.split('.')[1])
                );
            });
        } else if (sortingType == 'desc') {
            this._comments.sort((a, b) => b.Id - a.Id);

            this._comments.forEach(c => {
                c.Replies.sort((a, b) =>
                    Number(b.Id.split('.')[1]) - Number(a.Id.split('.')[1])
                );
            });
        } else if (sortingType == 'username') {
            this._comments.sort((a, b) => a.Username.localeCompare(b.Username));

            this._comments.forEach(c => {
                c.Replies.sort((a, b) => a.Username.localeCompare(b.Username));
            });
        }

        let result = [];
        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this._likes.length}`);
        result.push('Comments:');

        for (const comment of this._comments) {
            result.push(`-- ${comment.Id}. ${comment.Username}: ${comment.Content}`);

            for (const reply of comment.Replies) {
                result.push(`--- ${reply.Id}. ${reply.Username}: ${reply.Content}`);
            }
        }

        return result.join('\n');
    }
}


let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log();
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
console.log(art.toString('asc'));
