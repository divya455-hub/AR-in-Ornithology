# AR in Ornithology: An Augmented Reality Immersive Learning Application

An innovative Augmented Reality (AR) mobile application designed to bridge the gap between theoretical textbook learning and real-world bird observation. Traditional ornithology education suffers due to static textbooks and the geographic/economic constraints of physical field trips. This interactive app leverages mobile-based AR to offer accessible, safe, and resource-efficient wildlife studies.

---

## 📺 Project Demo 
* 🔗 **[Click Here to Watch the  Demo Video](https://drive.google.com/file/d/1rtHed5skU7V14d1o-H_SpHN3xNoJyMGx/view?usp=sharing)**  
<img width="300" height="300" alt="WhatsApp Image 2026-05-25 at 19 55 38" src="https://github.com/user-attachments/assets/3757ac2c-542c-426f-86c8-2ed3bb2e5a15" />
<img width="300" height="300" alt="WhatsApp Image 2026-05-25 at 19 55 37" src="https://github.com/user-attachments/assets/a75b65b0-2509-4ff3-ad53-a3e3166d1ee9" />
<img width="300" height="300" alt="WhatsApp Image 2026-05-25 at 19 55 37 (1)" src="https://github.com/user-attachments/assets/af227add-a64a-4e13-911b-23a83f29fcdd" />




---

## 🎯 Problem Statement
Learning bird identification in ornithology is highly challenging due to absolute dependence on static images, lack of physical resource materials, and hard-to-access field environments. This project introduces interactive spatial rendering tools to enable immersive 3D visualization, detailed anatomical exploration, and real-time auditory bird-call tracking within a unified mobile app space.

---

## 🛠️ Key App Feature Layout (MVP)
* **AR Plane Detection:** Dynamically scans spatial rooms or surfaces to calculate physical bounds using the mobile device camera.
* **Interactive 3D Placement:** Places high-fidelity 3D bird models inside the detected real-world natural habitat spaces.
* **Multi-Touch Gestures:** Intuitive user interaction setup supporting interactive 3D rotations to trace bird features closely.
* **Bird Calls Integration:** Features real-time audio libraries triggering realistic bird sounds/calls to optimize acoustic identification metrics.
* **Informational Overlays (UI):** Informative UI overlay panels displaying descriptive data sets about species names, behavior layouts, and regional habitats.

---

## 📐 Application Architecture & Flow
The application flow executes through structured state-machine phases:
1. **Launch & Onboarding:** Welcome screens and interactive system feature previews.
2. **Permissions Layer:** Prompts system requests for runtime Camera hardware access.
3. **Main Menu Ecosystem:** Segmented modules into:
   * `Bird Identification` | `Bird Calls` | `Bird Info` | `Explore in AR (Plane Tracking)`
4. **Placement Loop:** Executes surface plane analysis -> loads 3D geometry -> captures multi-touch interaction feedback without restarting the core loops.

---

## ⚙️ Technical Software Stack
* **Game Engine:** Unity (2022.3.x)
* **AR Core Engine:** AR Foundation (5.x) & Google ARCore XR Plug-in Management
* **IDE & Scripting:** Visual Studio 2022 | C# OOP Layouts
* **Deployment Standard:** Android SDK toolchains optimized for offline mobile use cases.

---

## 📁 Repository Clean Infrastructure
* `Assets/` — Interactive C# gesture tracking scripts, bird 3D assets, UI audio mixers.
* `Packages/` — Target system dependencies managing structural AR subsystems.
* `ProjectSettings/` — Input controls, spatial physics layer limits, and deployment presets.


