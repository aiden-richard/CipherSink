# CipherSink
CipherSink is a strategic two-player naval combat game inspired by [Battleship](https://en.wikipedia.org/wiki/Battleship_(game)), built using zero trust principles. The game is played on a peer to peer connection, needing no central server to operate. Game state is tracked using hashes and salts, ensuring every move can be verified without revealing where your ships are.

### How It's Secure
CipherSink uses cryptography to prevent cheating and enable honesty checks between players. One way it does this is by implementing public key cryptography to recognize returning players and verify their identities. For example, if I play with "Bob" now, I can play with him again in 2 weeks and be confident its the same person. We can prevent cheating by having both players share a salted hash of their gameboard at the start of the game, and after the game is over they must prove that their gameboard + the salt can produce the hash they shared at the start. Any manipulation of the gameboard will cause the hashes to not match.

### Game Rules:
 - Game is played on a 10x10 grid
 - Each player has 5 ships: one length 5, one length 4, two length 3, and one length 2
 - Before the game starts, players place their ships on their grid
 - Players take turns targeting a coordinate on their opponent's grid
 - The opponent responds hit or miss
 - If a ship is hit on all of its cells, it is considered sunk
 - The first player to sink all of their opponent's ships wins

## Screenshots
<img width="800" alt="Screenshot 2025-08-29 165813" src="https://github.com/user-attachments/assets/ef0c750f-9fc1-43d3-b37d-23b151923221" />
<img width="400" alt="Screenshot 2025-08-29 170425" src="https://github.com/user-attachments/assets/47288e2d-d93f-4a59-a3a1-9631cd3ca462" />
<img width="200" alt="Screenshot 2025-08-29 170442" src="https://github.com/user-attachments/assets/ea904397-15e0-4e30-9d60-e7f3f2676a5f" />
<img width="300" alt="Screenshot 2025-08-29 170456" src="https://github.com/user-attachments/assets/3a2ebdfa-f073-4c35-9032-8b95d2fd48e7" />
