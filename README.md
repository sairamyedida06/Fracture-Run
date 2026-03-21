# FractureRun 🏃

A fast-paced **3D endless runner** built in Unity for mobile (Android), where platforms fall away beneath your feet as you race to survive. Tap to change direction, collect pickups, and push your high score as the speed scales up.

**Available on:**
- [Google Play](#) *(closed testing)*
- [Amazon Appstore](#)
- [itch.io](#)

---

## 📱 Gameplay

- Tap/click to switch direction between two axes (Z and X)
- Platforms fall away shortly after you leave them
- Collect pickups scattered across platforms for bonus score
- Speed increases automatically as your score climbs
- Survive as long as possible — beat your own high score

---

## 🏗️ Architecture Overview

This project was built with a focus on **clean, modular architecture** and **separation of concerns**. Each system is independent and communicates through minimal direct references.

```
FractureRun/
├── Player/
│   └── PlayerController.cs       # Input, movement, direction switching
├── Platform/
│   ├── Platform.cs               # Fall logic, pool return trigger
│   ├── PlatformPool.cs           # Object pool (Queue-based)
│   └── PlatformSpawner.cs        # Procedural spawn loop with direction bias
├── Collectibles/
│   └── Collectible.cs            # Trigger detection, score add, VFX + SFX
├── Camera/
│   └── CameraFollow.cs           # Smooth Lerp follow with Y-threshold guard
├── Environment/
│   └── BackgroundColourChange.cs # Coroutine-based random skybox cycling
├── UI & Game Flow/
│   ├── GameManager.cs            # Core game state, score, speed scaling, save
│   └── Menu.cs                   # Main menu, high score display
```


## ⚙️ Key Systems

### 🔁 Object Pooling — `PlatformPool.cs`
Platforms are pre-instantiated at startup into a `Queue<GameObject>`. Instead of destroying and re-creating platforms every frame, they are dequeued on spawn and re-enqueued on return. This keeps garbage collection minimal and maintains a **consistent 60 FPS on mid-range Android devices.**

```csharp
// Get a platform from the pool
GameObject platform = pool.GetPlatform();

// Return it when done
pool.ReturnPlatform(gameObject);
```

### 🌀 Procedural Spawning — `PlatformSpawner.cs`
A coroutine-based spawn loop runs continuously, calculating the next platform position based on a **weighted random direction bias** (Z-axis favoured over X-axis at ~65/35). Spawning pauses automatically if the active platform count hits the defined cap.

```csharp
// Direction bias: ~65% Z-axis, ~35% X-axis
int randomDirection = Random.Range(0, 20);
if (randomDirection > 12)
    nextSpawnPosition.x += 1;
else
    nextSpawnPosition.z += 1;
```

### 🏃 Player Controller — `PlayerController.cs`
Simple, responsive tap input toggles the player between two fixed rotations (0° and 90° Y-axis), changing the movement direction. Speed is controlled externally by `GameManager` for clean separation.

### 🎯 Collectible System — `Collectible.cs`
On trigger enter, collectibles add score, spawn a VFX prefab at position, play a spatial SFX clip via `AudioSource.PlayClipAtPoint`, then destroy themselves. Fully self-contained — no manager dependency.

### 📈 Dynamic Difficulty — `GameManager.cs`
Every `scoreStep` points, the player's move speed increases by `speedIncreaseAmount` up to a defined `maxSpeed`. Score increments via a coroutine every second, separate from frame rate.

```csharp
// Speed scaling logic
if (score >= nextSpeedScore)
{
    PlayerController.Instance.currentMoveSpeed += speedIncreaseAmount;
    PlayerController.Instance.currentMoveSpeed = 
        Mathf.Min(PlayerController.Instance.currentMoveSpeed, maxSpeed);
    nextSpeedScore += scoreStep;
}
```

### 💾 High Score Persistence — `GameManager.cs` + `Menu.cs`
High score is saved and loaded using `PlayerPrefs`. Only saved if the current score beats the stored value. Displayed on the main menu on next launch.

### 📷 Camera Follow — `CameraFollow.cs`
Calculates a fixed offset at Start and smoothly Lerps to maintain it. Includes a **Y-threshold guard** — camera only follows when player is above a certain Y position, preventing the camera from chasing the player into the fall.

### 🌅 Skybox Cycling — `BackgroundColourChange.cs`
A simple coroutine cycles through a `Material[]` array of skyboxes every 10 seconds using `RenderSettings.skybox`, with `DynamicGI.UpdateEnvironment()` called to update lighting after each swap.

---

## 🛠️ Technical Details

| Detail | Value |
|---|---|
| Engine | Unity (URP) |
| Language | C# |
| Target Platform | Android (Mobile) |
| Target Frame Rate | 60 FPS |
| Input System | Legacy Input (Mouse/Touch) |
| Rendering Pipeline | Universal Render Pipeline (URP) |

---

## 📦 Build & Run

### Requirements
- Unity 2022.3 LTS or above
- Android Build Support module installed
- URP package

### Steps
1. Clone the repo
```bash
git clone https://github.com/sairamyedida06/fracturerun.git
```
2. Open in Unity Hub → Select correct Unity version
3. Open `Assets/Scenes/Menu` scene
4. Hit **Play** to test in editor, or switch platform to **Android** and build

---

## 🎮 Design Decisions

**Why Object Pooling?**
Mobile devices have limited memory and GC spikes cause frame drops. Pooling platforms keeps allocations at startup only, giving smooth runtime performance.

**Why weighted direction bias?**
Pure 50/50 random felt chaotic and unfair. A 65/35 Z-to-X bias makes the path feel more natural and forward-moving while still being unpredictable.

**Why a Y-threshold on the camera?**
Without it, the camera would follow the player falling off the edge — which looked bad and felt disorienting before the game over screen appeared.

**Why separate Pool and Spawner scripts?**
Keeping `PlatformPool` and `PlatformSpawner` as separate components means the pool can be reused for other object types in future, and each script has a single clear responsibility.

---

## 👤 Author

**Yedida Sai Ram**
Unity Game Developer
- GitHub: [github.com/sairamyedida06](https://github.com/sairamyedida06)
- Email: sairamyedidaoffl@gmail.com


---

## 📄 License

This project is open for viewing and learning purposes.
For commercial use or redistribution, please contact the author.
