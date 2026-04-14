# DSH Final Project

Proyecto final desarrollado en **Unity** para **Meta / Oculus Quest**, centrado en una experiencia inmersiva de aprendizaje sobre el uso de un **equipo de experimentación a escala piloto**.

## Descripción del proyecto

El objetivo del proyecto es recrear en realidad virtual un equipo de laboratorio o planta piloto, permitiendo al usuario:

- observar el entorno y los componentes del equipo,
- identificar elementos concretos,
- responder preguntas sobre el funcionamiento,
- realizar acciones sobre el sistema,
- recibir feedback inmediato sobre si la respuesta o acción realizada es correcta.

La experiencia está pensada como una simulación educativa e interactiva en VR.

---

## Tecnologías principales

- **Unity**
- **OpenXR**
- **XR Interaction Toolkit**
- **Input System**
- **Android Build Support** para compilación en Quest

---

## Versión de Unity

Todos los integrantes del equipo deben usar **la misma versión exacta de Unity**.

> Versión acordada del proyecto: **Unity 6.3 LTS**

No se debe actualizar la versión por cuenta propia sin avisar al resto del grupo.

---

## Requisitos para cada integrante

Cada miembro del equipo debe tener instalado:

- **Unity Hub**
- **Unity 6.3 LTS**
- Módulos de Unity:
  - **Android Build Support**
  - **Android SDK & NDK Tools**
  - **OpenJDK**
- **Git**
- **Visual Studio Code** o editor equivalente
- Cuenta de **GitHub** con acceso al repositorio

### Nota importante sobre las pruebas en Quest

El proyecto puede desarrollarse desde Linux o Windows, pero las **pruebas reales con las gafas Quest** se realizarán desde un equipo con **Windows** y acceso al dispositivo.

Por tanto:

- el desarrollo puede repartirse entre todos,
- pero la validación final en hardware la harán los compañeros responsables de pruebas en Quest.

---

## Organización básica del repositorio

La estructura del proyecto debe mantenerse lo más limpia posible.

Posibilidad de organización de carpetas dentro de `Assets`:

```text
Assets/
├── Audio/
├── Materials/
├── Models/
├── Prefabs/
├── Scenes/
├── Scripts/
├── UI/
├── XR/
└── Textures/
