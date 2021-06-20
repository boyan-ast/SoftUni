class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = new Map();;
        this._likes = new Set();
    }

    get likes() {
        if (this._likes.size == 0) {
            return `${this.title} has 0 likes`;
        } else if (this._likes.size == 1) {
            return `${this._likes.values().next().value} likes this story!`
        } else {
            return `${this._likes.values().next().value} and ${this._likes.size - 1} others like this story!`;
        }
    }

    like(username) {
        if (this._likes.has(username)) {
            throw new Error('You can\'t like the same story twice!');
        } else if (username == this.creator) {
            throw new Error('You can\'t like your own story!');
        } else {
            this._likes.add(username);
            return `${username} liked ${this.title}!`;
        }
    }

    dislike(username) {
        if (!this._likes.has(username)) {
            throw new Error('You can\'t dislike this story!');
        } else {
            this._likes.delete(username);
            return `${username} disliked ${this.title}`;
        }
    }

    comment(username, content, id) {
        if (id == undefined || !this._comments.has(id)) {
            let id = this._comments.size + 1;
            let comment = {
                id,
                username,
                content,
                replies: new Map()
            };

            this._comments.set(id, comment);

            return `${username} commented on ${this.title}`;
        } else if (this._comments.has(id)) {
            let commentReplies = this._comments.get(id).replies;
            let replyId = `${id}.${commentReplies.size + 1}`;
            let newReply = {
                id: replyId,
                username,
                content
            }
            commentReplies.set(commentReplies.size + 1, newReply);

            return 'You replied successfully';
        }
    }

    toString(sortingType) {
        let result = [];
        result.push(`Title: ${this.title}`);
        result.push(`Creator: ${this.creator}`);
        result.push(`Likes: ${this._likes.size}`);
        result.push('Comments:');

        if (sortingType == 'asc') {
            let sortedComments = [...this._comments].sort((a, b) => a[0] - b[0]);

            for (const [id, comment] of sortedComments) {
                result.push(`-- ${id}. ${comment.username}: ${comment.content}`);

                if (comment.replies.size > 0) {
                    let commentReplies = [...comment.replies].sort((a, b) => a[0] - b[0]);

                    for (const [replyId, reply] of commentReplies) {
                        result.push(`--- ${reply.id}. ${reply.username}: ${reply.content}`)
                    }
                }
            }
        } else if (sortingType == 'desc') {
            let sortedComments = [...this._comments].sort((a, b) => b[0] - a[0]);

            for (const [id, comment] of sortedComments) {
                result.push(`-- ${id}. ${comment.username}: ${comment.content}`);

                if (comment.replies.size > 0) {
                    let commentReplies = [...comment.replies].sort((a, b) => b[0] - a[0]);

                    for (const [replyId, reply] of commentReplies) {
                        result.push(`--- ${reply.id}. ${reply.username}: ${reply.content}`)
                    }
                }
            }
        } else if (sortingType == 'username') {
            let sortedComments = [...this._comments].sort((a, b) => a[1].username.localeCompare(b[1].username));

            for (const [id, comment] of sortedComments) {
                result.push(`-- ${id}. ${comment.username}: ${comment.content}`);

                if (comment.replies.size > 0) {
                    let commentReplies = [...comment.replies].sort((a, b) => a[1].username.localeCompare(b[1].username));

                    for (const [replyId, reply] of commentReplies) {
                        result.push(`--- ${reply.id}. ${reply.username}: ${reply.content}`)
                    }
                }
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
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
