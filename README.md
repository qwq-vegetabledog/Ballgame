# Unity Running game

This project provides a robust foundation for a 3D game, featuring a character controller with built-in animations, a functional menu system with pause logic, and a dynamic "jumping fish" environmental script.
---

## ⌨️ Controls

| Input | Action |
| :--- | :--- |
| **W / S** | Move Forward / Backward |
| **A / D** | Rotate Character |
| **Space** | Jump |
| **Escape** | Pause / Resume / Show Menu |

---

## 💡 Quick Tips
* **Gravity**: If the jump feels too floaty, increase the 'gravityValue' in the 'Playercontrols' script.
* **Pause Logic**: The game uses 'Time.timeScale = 0' to pause. Ensure your other scripts use 'Time.deltaTime' to remain compatible with this system.
---

