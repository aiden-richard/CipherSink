# CipherSink
CipherSink is a strategic two-player naval combat game inspired by [Battleship](https://en.wikipedia.org/wiki/Battleship_(game)), built using zero trust principals. The game is played on a peer to peer connection, needing no central server to operate. Game state is tracked using hashes and salts, ensuring every move can be verified without revealing where your ships are.

### Why Its Secure
CipherSink uses cryptography to prevent cheating and enable honesty checks between players. It does this by implementing public key cryptography to recognize returning players and verify their identities. For example, if I play with "Bob" now, I can play with him again in 2 weeks and be confident its the same person. We can prevent cheating by having both players share a hash of their gameboard at the start of the game, and after the game is over they must prove that their gameboard can produce the hash they shared at the start. Any manipulation of the gameboard will cause the hashes to not match.

### Game Rules:
 - Game is played on a 10x10 grid
 - Each player has 5 ships: one length 5, one length 4, two length 3, and one length 2
 - Before the game starts, players place their ships on their grid
 - Players take turns targeting a cordinate on their opponent's grid
 - The opponent responds hit or miss
 - If a ship is hit on each of its cells, it is considered sinked
 - The first player to sink all of their opponent's ships wins

# Examples:
### How to start the game up. (with screenshots or viedo)

### Screenshot of main page - (insert photo)

### Screenshots or Video showing a game being played - (insert multiple photos/video)
