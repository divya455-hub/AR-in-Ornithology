# AR in Ornithology: An Augmented Reality Immersive Learning Application

An innovative Augmented Reality (AR) mobile application designed to bridge the gap between theoretical textbook learning and real-world bird observation. Traditional ornithology education suffers due to static textbooks and the geographic/economic constraints of physical field trips. This interactive app leverages mobile-based AR to offer accessible, safe, and resource-efficient wildlife studies.

---

## 📺 Project Demo & Flow Visuals
* 🔗 **[Click Here to Watch the Presentation and Demo Video](PASTE_YOUR_YOUTUBE_VIDEO_LINK_HERE)**
* *Tip: Drag and drop your architecture flowcharts or app screen captures directly here inside GitHub to display them.*

---

## 🎯 Problem Statement
Learning bird identification in ornithology is highly challenging due to absolute dependence on static images, lack of physical resource materials, and hard-to-access field environments. This project introduces interactive spatial rendering tools to enable immersive 3D visualization, detailed anatomical exploration, and real-time auditory bird-call tracking within a unified mobile app space.

---

## 🛠️ Key App Feature Layout (MVP)
* **AR Plane Detection:** Dynamically scans spatial rooms or surfaces to calculate physical bounds using the mobile device camera.
* **Interactive 3D Placement:** Places high-fidelity 3D bird models inside the detected real-world natural habitat spaces.
* **Multi-Touch Gestures:** Intuitive user interaction setup supporting interactive 3D rotations and zooming scales to trace bird anatomy closely.
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


