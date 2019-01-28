# Grasshopper Live
_Real-time collaborative visual scripting_

![Grasshopper](/Videos/GrasshopperLiveAnimationLogo.gif)

Inspired by the collaborative nature of web applications like [Google docs](https://www.edu.uwo.ca/ISC2/technology/img/google.gif) and Google sheets, _Grasshopper Live_ is a system to synchronize [Grasshopper](https://www.grasshopper3d.com/) definitions in real-time, allowing multiple users to modify the same file from different environments. As a user, you simply checkout the latest version of your definition, activate Grasshopper live together with your friends, and you are then able to see eachothers changes to the document (like adding/deleting/moving components).

## Context
_Grasshopper Live_ was developed from scratch under 24 intense hours at the [AEC Hackathon](http://aechackathon.com) January 2019, in Copenhagen, Denmark. Hack team consisted of:

- [Charlie Portelli](https://github.com/Crashnorun), CORE Studio | Thornton Tomasetti
- [Elcin Ertugrul](https://github.com/eertugrul), CORE Studio | Thornton Tomasetti
- [Emil Poulsen](https://github.com/EmilPoulsen), CORE Studio | Thornton Tomasetti
- [Paul Poinet](https://github.com/PaulPoinet), CITA

## Content / Tech stack
The repo consists of mainly two parts: A node application running the server (javscript) and the client application syncing the changes to the GH doc (C#). The tech stack includes: `Grasshopper SDK`, `SocketIoClientDotNet`, `Node.js`, `Express.js`, `Socket.io`.

## Roadmap
- General cleanup. Stabalize outcome from hackathon.
- Record versions and allow time-independent checkouts
- Full version control
- Resthopper/compute and viz in browser.

## Demo
![Demo](/Videos/hack_demo.gif)

_Changes made to the Grasshopper document on the right laptop is reflected (real-time) on the left laptop._

## License
[MIT](/LICENSE)
