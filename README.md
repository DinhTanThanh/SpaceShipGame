# 🚀 SpaceShip

> A fast-paced 2D space ship developed with Unity 6 and C#.

![Banner](Assets/Image/MenuScene/Poster_SpaceShip.jpeg)

---

## 🎮 Gameplay Preview

Trailer:
[https://youtu.be/xxxxxxxx](https://youtu.be/JXzm-YuT5g4)

Play the Game:
[https://yourname.itch.io/spaceship](https://dinh-tan-thanh.itch.io/spaceship)

Portfolio: [https://dinhtanthanh.github.io](https://dinhtanthanh.github.io/project-detail.html)

---

## 📖 Overview

SpaceShip is a solo-developed 2D action game where players pilot a combat spaceship through dangerous sectors of space, battle intelligent enemies, defeat unique bosses, and collect resources to survive.

This project was created to strengthen my Unity gameplay programming skills while applying software engineering principles to build scalable and maintainable systems.

---

## ✨ Game Features

- 🚀 Fast-paced 2D space shooter gameplay
- 👾 Three handcrafted stages
- 💀 Three unique boss battles
- 🤖 Enemy AI with different behaviors
- 🎒 Inventory and item drop system
- ⚡ Multiple player skills and abilities
- 🔋 Energy (KI) management system
- 💥 Various enemy attack patterns
- 🖱️ Mouse-aimed movement and intuitive combat controls
- ♻️ Optimized using Object Pooling
- 🏗️ Modular architecture using Singleton, Observer Pattern, and ScriptableObject
- 🎵 Sound effects and background music
- 📈 Performance-focused gameplay systems

---

## 🛠 Technical Highlights

This project demonstrates my experience with:

- Unity 6
- C#
- Object Pooling
- Singleton Pattern
- Observer Pattern
- ScriptableObject
- State-based Boss AI
- Event-driven UI
- Inventory System
- Physics2D
- Scene Loading
- Audio Management

---

## 🎮 Controls

| Action | Key |
|--------|-----|
| Move spaceship | 🖱️ Mouse Cursor |
| Shoot | 🔫 Left Mouse Button |
| Dash | ⚡ W / A / S / D |
| Diagonal Dash | ↖️ W+A / W+D / S+A / S+D |
| Activate Skills | 🚀 1 / 2 / 3 / 4 / 5 / 6 / 7 |


---

## 🏗 Architecture

### Core Systems

- Player
- Enemy AI
- Boss AI
- Inventory System
- Audio Manager
- Object Pool Manager
- Scene Manager
- UI System
- Game Manager
### Design Patterns

- Singleton
- Observer Pattern
- ScriptableObject
- Object Pooling
- Dirty Flag UI Updates
---
# 📈 Performance Profiling

Performance was measured using **Unity Profiler** on a **Windows Standalone Development Build** during the most demanding gameplay scenario, including the highest number of enemies, bullets, meteorites, UI updates, and visual effects.

## Profiling Environment

| Item | Value |
|------|------|
| Unity Version | Unity 6 |
| Platform | Windows Standalone (.exe) |
| Profiling Tool | Unity Profiler |
| Build Type | Development Build + Autoconnect Profiler |
| Test Scenario | Peak gameplay (maximum enemies, bullets, meteorites, UI, and VFX) |

---

## Performance Results

| Metric | Result |
|---------|---------|
| Average FPS | **~143 FPS** |
| CPU Frame Time | **~7 ms** |
| Gameplay GC Allocation | **0 B/frame** |
| Batch Count | **55** |
| SetPass Calls | **10** |
| Triangles | **≈2,500** |
| Vertices | **≈2,900** |
| Total Used Memory | **~650 MB** |
| Managed Heap | **5.9 MB** |

---

## Unity Profiler

### CPU Usage

![CPU Profiler](Image/MenuScene/Profiler_CPU.png)

### Timeline

![Timeline](Image/MenuScene/Profiler_Timeline.png)

### Memory

![Memory Profiler](Image/MenuScene/Profiler_Memory.png)

---

# ♻️ Performance Optimization

Performance optimization was considered throughout development to ensure smooth gameplay during large-scale combat scenarios.

Implemented optimizations include:

- ✅ Object Pooling for bullets, enemies, explosions, and visual effects
- ✅ Eliminated runtime allocations during gameplay (**0 B/frame GC Allocation**)
- ✅ Maintained approximately **143 FPS (~7 ms CPU Frame Time)** under peak gameplay
- ✅ Observer Pattern for event-driven communication
- ✅ Dirty Flag UI updates to reduce unnecessary UI redraws
- ✅ Modular gameplay systems for easier maintenance and future scalability

---

## 📚 What I Learned

During this project I improved my understanding of:

- Gameplay Programming
- Software Architecture
- Design Patterns
- Performance Optimization
- AI Behaviour
- Unity UI
- Project Organization

---

## 🧰 Built With

- Unity 6
- C#
- Visual Studio
- Git
- GitHub

---

## 👤 Developer

Đinh Tấn Thành

Unity Game Developer

LinkedIn:
[https://www.linkedin.com/in/dinhtanthanh](https://www.linkedin.com/in/dinhtanthanh/)

Portfolio:
https://dinhtanthanh.github.io/

Email:
dinhtanthanh19@gmail.com
