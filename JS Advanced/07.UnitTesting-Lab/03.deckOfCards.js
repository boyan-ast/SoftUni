function printDeckOfCards(cards) {
    function createCard(face, suit) {
        let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let suits = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663'
        }

        if (!faces.includes(face) || !suits.hasOwnProperty(suit)) {
            throw new Error(`Invalid card: ${face}${suit}`);
        }

        let card = {
            face,
            suit
        }

        card.toString = () => {
            return `${card.face}${suits[suit]}`;
        }

        return card;
    }

    let deck = [];

    try {
        for (let card of cards) {
            let cardSuit = card.substring(card.length - 1);
            let cardFace = card.substring(0, card.length - 1);

            deck.push(createCard(cardFace, cardSuit).toString());
        }
        console.log(deck.join(' '));
    } catch (error) {
        console.log(error.message);
    }
}


printDeckOfCards(['AS', '10D', 'KH', '2C']);
printDeckOfCards(['5S', '3D', 'QD', '1C']);