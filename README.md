# HACDN.Sharp [![Build status](https://ci.appveyor.com/api/projects/status/kxxwh8i6x0sc73rf/branch/master?svg=true)](https://ci.appveyor.com/project/JordanZeotni/hacdn-sharp/branch/master)

### I recommend using https://gbatemp.net/threads/cdnx-cdn-downloader.504155/ instead of HACDN or its port(s), CDNX is much more optimized, has less of a chance of banning you and is also in C#. If you want to read this for fun, I'm not stopping you and if you want to use my app anyways, you're crazy but go ahead.

## What's different???
Understandably, when a derivative version of an application is created, it is questioned what exactly is the benefit of this over the original? Well let me outline it in a list for your convenience:

   1. This application uses "using", Basically "using" disposes unneeded memory allocations after they are done being used. Unless I'm crazy, I saw very many disposable methods being left as is.
   2. It's written in C#. Self-explanatory.
   3. This application does not use goto statements 
   4. I personally think my code is more organized, but that's subjective; you decide.
   5. I plan on writing this in mono, or just trying to build it as is in mono. Stay tuned for details.

## Usage:
Put in the title id of a Switch game you purchased on the eShop, put in your device id and then click download.
The title ID is the identifier of a game, you can see a reasonably up-to-date listing on SwitchBrew.
The device ID is extractable from your PRODINFO partition.

## Dependencies:

   * Requires your cert, hactool and a filled keys.txt file.
   * .Net Framework 4.7.1
