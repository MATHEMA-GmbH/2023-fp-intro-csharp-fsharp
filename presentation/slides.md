---
theme: 'default'
title: 'modern linux cli tools'
# real width of the canvas, unit in px
canvasWidth: 980

src: ./pages/title.md
---

---
layout: image-right-with-caption
image: './images/HappyTowelDay.jpg'
imageCaption: 'https://commons.wikimedia.org/wiki/File:HappyTowelDay.jpg'
---

# "modern" is relative...

**Douglas Adams**

I've come up with a set of rules that describe our reactions to technologies:

<v-clicks>

- Anything that is in the world **when you're born** is normal and ordinary and is just a natural part of the way the world works.
- Anything that's invented **between when you're fifteen and thirty-five** is new and exciting and revolutionary and you can probably get a career in it.
- Anything invented **after you're thirty-five** is against the natural order of things.

</v-clicks>

<style>
h1 {
    font-size: 26px;
}
li {
  line-height: 130% !important;
  margin: 10px 0;
}
</style>

<!--

TODOs:

- other image?
- font: italic
- line-spacing: remove extra line spacing in within bullet points
 -->

---

# Target audience

- linux desktop CLI users
- linux admins
- docker users
- ...

```
  __________________________________________
 / This is the year of linux on the desktop \
|                                            |
|          ...Windows10 has WSL ;-)          |
 \                                          /
  ------------------------------------------
        \   ^__^
         \  (oo)\_______
            (__)\       )\/\
                ||----w |
                ||     ||
```

---

# Linux tooling philosophy

- **do one thing (and only one thing!) well**

- **chaining**

- _sound familiar? (hint: functional programming...)_

---

# Why? Improvements to...

- **productivity**

- **optics**
    - "unix porn" (`PS1`, `ls`, ...)

---

# Learn the basics

VS Code is cool, but it is not a CLI tool

<div grid="~ cols-2 gap-4">
<div>

- **Emacs** and **Vim**:
    - navigation within file
    - cut, copy & paste
    - navigation between files
    - and how to exit
    - pick one and become fluent
- Learn basic cli commands: `cd`, `ls`, `cat`, `less`, `find`, `grep`, `sed`, `tail`, `awk`, `dd`, `rsync`, ...
- Combine using pipes and redirection

</div>
<div>
<div grid="~ cols-2 gap-4">
<img src="/images/emacs.png"/>
<img src="/images/Vimlogo.svg" width="120" />
</div>
</div>
</div>


---

# terminal and shell: what's the difference?

<div grid="~ cols-4 gap-4">
<div>

```bash
+--------------------+
|     "terminal"     |
+--------------------+
|                    |
|  +--------------+  |
|  |              |  |
|  |    "shell"   |  |
|  |              |  |
|  +--------------+  |
|                    |
+--------------------+
```

</div>
<div class="col-span-3">

**terminal**

- **colors** (16 or more), 
- **fonts** (utf8, ligatures, emojis, ...)
- **interactions**
    - keyboard shortcuts
    - mouse interaction (copy & paste, scrolling, selection, ...)

**shell**

- **everything else** (f.ex. **`PS1`**, scripting language)

</div>
</div>

---

## terminal

**What is the best terminal?**

- use your default

**Unicode, Emojis, Fonts, Image support (!)**

- but think about enriching your output!

- Emojis: <noto-thumbs-up class="inline"/> <noto-check-mark-button class="inline"/> <noto-collision class="inline"/> <noto-victory-hand class="inline"/> 
  <noto-pile-of-poo class="inline"/> <noto-speech-balloon class="inline"/> <noto-zany-face class="inline"/> € ★

<img
  class="absolute bottom-20 right-0 w-130"
  src="/images/terminal-with-icons.png"
/>
<img
  class="absolute top-20 right-4 w-130"
  src="/images/terminal-with-image-support.png"
/>


---

## Popular shells

- bash
- zsh
- fish
- dash (embedded)

---
layout: two-cols
---

### bash

- https://www.gnu.org/software/bash/
- package manager
    - bash-it: <gh-stars count="13k"/> https://github.com/Bash-it/bash-it
    - oh-my-bash: <gh-stars count="4k"/> https://ohmybash.github.io

### zsh

- https://www.zsh.org/
- package manager
    - oh-my-zsh: <gh-stars count="157k"/> https://ohmyz.sh

::right::

### fish: The new kid on the block

- https://fishshell.com
- package manager
    - fisher: <gh-stars count="6k"/> https://github.com/jorgebucaran/fisher
    - oh-my-fish: <gh-stars count="9k"/> https://github.com/oh-my-fish/oh-my-fish

---

<!-- shell / PS1 -->

# PS1

PS1: alias for "prompt"

- default: `username@machinename:~/some/location $`
- `$PWD` present working directory

Extra, nice-to-have information

- only show relevant parts (hide user/machine name on local machine)
- compact location (`$PWD`)
- git status
- environment infos (node / .NET / Java / Python / etc version)

---

<!-- shell / PS1 -->

# PS1: Powerline

started as fancy statusline for `vim`...

- <gh-stars count="13k"/> https://github.com/powerline/powerline
- good-looking default settings
  - shortens `$PWD`
  - adds git status
  - stable & customizable
- available for `zsh`, `bash`, etc
- category: unix-porn

<img
  class="absolute bottom-20 right-20"
  src="/images/powerline-shell-example.png"
/>


---

<!-- shell / PS1 -->

# PS1: liquidprompt

simple prompt

- <gh-stars count="4k"/> https://github.com/nojhan/liquidprompt
- simpler default compared to Powerline
  - shortens `$PWD`
  - adds git status
  - can be combined with Powerline
- available for `zsh`, `bash`, etc
- category: unix-porn

<img
  class="absolute bottom-40 right-20"
  src="/images/liquidprompt-default-med.png"
/>
<img
  class="absolute bottom-20 right-20"
  src="/images/liquidprompt-powerline-med.png"
/>

---

<!-- shell / PS1 -->

# PS1: Starship

the new kid on the block

- <gh-stars count="33k"/> https://github.com/starship/starship
- cross-plattform, cross-shell
- stylish
- great defaults for many environments
- easy to configure
- category: unix-porn

<img
  class="absolute top-10 right-0 w-100"
  src="/images/starship-prompt.png"
/>
<img
  class="absolute bottom-10 right-5 w-100"
  src="/images/starship.gif"
/>

---

# tmux

terminal-independent shell UI

- <gh-stars count="28k"/> https://github.com/tmux/tmux
- terminal multiplexer
- "tabs" and "split screen" features: terminal independent
- detachable sessions
- plugin system & package manager (of course)
- customizable
- scriptable: f. ex. `tmuxinator`

<!--
- new window
- navigate between windows
- rename window
- split screen
- navigate between screens
- zoom screen
- demo2: hugo folder with tmuxinator config
- demo3: rpi - detach: Ctrl+b d / attach: tmux a / tmux ls
- open with named session: tmux new -s foo
-->

---

# byobu

`tmux`-wrapper for non-vim users

- (mirrored repo: ~500 stars) http://byobu.co/
- Keybindings `F1` - `F12`
- Sensible defaults (layout, info line)
- category: productivity

---

# mob <lightbulb/>

Smooth git handover

- <gh-stars count="1k"/> https://mob.sh/
- remote ensemble or pair programming using screen sharing

<img
  class="absolute top-20 right-20 w-50"
  src="/images/mob-logo.svg"
/>

```bash
## first user
mob start 5
mob next

## second user
mob start 5
mob next

## any user, wanting to make a normal commit
mob done
```

---

# ranger

file explorer

- <gh-stars count="13k"/> https://ranger.github.io
- 2 layout options
    - miller columns ("mac" style)
    - multipane (similar to Midnight commander)
- powerful preview mode and program launcher (word, music, ...)
    - with image support for certain terminals (`iterms2`, `urxvt`, `kitty`) not `gnome-terminal` (!)
- key bindings: see `~/.config/ranger/rc.conf` starting at line ~300...
- category: navigation, file system

<!--
Demo:
- kitty with image preview
- copy `yy` & paste `pp`
-->

---

# Emacs: wdired-mode

- for Emacs users
- https://www.gnu.org/software/emacs/manual/html_node/emacs/Wdired.html
- `emacs -nw .` emacs in current directory in terminal (`-nw`: non-window mode)
- `M-x wdired-change-to-wdired-mode`
- edit (using all emacs features)
- finish: `C-c C-c`
- exit


<!--
Demo:
- open demo folder
- change some file names
-->

---
layout: two-cols
---

# tldr

man pages can be difficult

- <gh-stars count="44k"/> https://tldr.sh/
- tldr: implemented in many languages (js, ruby, python, perl, haskell, etc)
- Demo: `ln`, `tar`, `scp`

::right::

<v-click>
<img
  class="absolute top-20 right-5 w-120"
  src="/images/tldr-ln.png"
/>
</v-click>
<v-click>
<img
  class="absolute top-20 right-5 w-120"
  src="/images/tldr-tar.png"
/>
</v-click>
<v-click>
<img
  class="absolute top-20 right-5 w-120"
  src="/images/tldr-scp.png"
/>
</v-click>

<style>
.slidev-code * {
    font-size: x-small
}
</style>

---

# McFly

an upgraded <kbd>Ctrl R</kbd> **where history results make sense for what you're working on right now**

- <gh-stars count="5k"/> https://github.com/cantino/mcfly
- category: history search

> McFly replaces your default <kbd>Ctrl R</kbd> shell history search with an intelligent search engine that takes into account your working directory and the context of recently executed commands. McFly's suggestions are prioritized in real time with a small neural network.

---

# bat

`cat` & `less` with syntax highlighting

- <gh-stars count="40k"/> https://github.com/sharkdp/bat
- hint: can be used as preview by `ranger`...
- category: file preview

<!--
Demo:
- cd some-code
- cat Demo1.fs
- less Demo1.fs
- bat Demo1.fs
-->

---

# ripgrep <lightbulb/>

very fast `grep` replacement

- <gh-stars count="37k"/> https://github.com/BurntSushi/ripgrep
- `ripgrep` recursively searches directories for a regex pattern
- sensible defaults: respect `.gitignore`, ignores hidden files & folders
- command: `rg`
- category: search

- use `rg --hidden -g '!.git' "your search"` to search all hidden folder except `.git`
  - create an alias (maybe `rgh`?)...

<!--
Demo:
- single file -> "foo" -> found
- within .git folder -> "foo" -> not found
- within node_modules folder -> "foo" -> not found by default, because in .gitignore
- within node_modules folder -> "foo" -> found using `rg --hidden -g '!.git'`
-->

---

# ripgrep-all

ripgrep, but also search in PDFs, E-Books, Office documents, zip, tar.gz, sqlite (!), etc

- <gh-stars count="5k"/> https://github.com/phiresky/ripgrep-all
- command: `rga`
- faster than `pdfgrep` (see website for a benchmark)
- category: search
- Demo: search in Manning books folder

<!--
cd ~/Dropbox/Apps/Manning\ Books/
rga Vladimir
-->

---

# fzf

interactive fuzzy search

- <gh-stars count="51k"/> https://github.com/junegunn/fzf
- pipe any line based input to fzf: Example `find * -type f | fzf`
- good integration with other tools
- `Alt+c`: quick `cd` navigation
- nice helper methods for
    - files & directories `cd **<TAB>`
    - kill `kill -9 <TAB>`
    - host names `ssh **<TAB>`
    - environment variables & aliases `unset **<TAB>`, `export **<TAB>`, `unalias **<TAB>`
- category: search

<!--


- `fzf -m` multiselect
- select files with Shift+TAB
- search for "bob"
- find * -type f | fzf -m

cd .
search for  "linux"
cat slides.md | fzf
-->

---

# fd <lightbulb/>

simple alternative to `find`

- <gh-stars count="27k"/> https://github.com/sharkdp/fd
- "The command name is 50% shorter than `find`"
- Convenient syntax `fd PATTERN` (instead of `find -iname '*PATTERN*'`)
- Sensible defaults: `.gitignore`, ignore hidden files/folders
- fast
- category: search

---
layout: screencast
image: './screencasts/out2c.gif'
---

# hyperfine

benchmarking tool

- <gh-stars count="15k"/> https://github.com/sharkdp/hyperfine

```bash
# comparing `fd` with `find`
hyperfine --warmup 3 \
    'fd -e jpg -uu' \
    'find -iname "*.jpg"' 
```

- category: benchmarking

<!-- 
hyperfine --warmup 3 'fd -e jpg -uu' 'find -iname "*.jpg"' 
-->

---

# progress

monitor any kind of "copy"

- <gh-stars count="6k"/> https://github.com/Xfennec/progress
- attach to any kind of copy, even after the fact
- category: monitoring

``` bash
No command currently running: cp, mv, dd, tar, cat, rsync, grep, fgrep, egrep, cut, sort, md5sum,
sha1sum, sha224sum, sha256sum, sha384sum, sha512sum, adb, gzip, gunzip, bzip2, bunzip2, xz,
unxz, lzma, unlzma, 7z, 7za, zcat, bzcat, lzcat, split, gpg, or wrong permissions.
```

<!--
- `scp ubuntu*.iso pi@camel:~/`
- `watch progress`
-->

---

# Ultimate Plumber (up)

interactive REPL for shell piping

- <gh-stars count="8k"/> https://github.com/akavel/up
- interactive piping
- instant live preview
- category: search, file manipulation, interactive

<img
  class="absolute top-20 right-20 w-50"
  src="/images/ultimate-plumber-logo.svg"
/>

<!--
- cd some-project
- cat Demo1.fs | up
- grep credit
-->

---

# lolcat <openmoji-unicorn style="display:inline"/>

Rainbows and unicorns

- <gh-stars count="5k"/> https://github.com/busyloop/lolcat
- category: fun, unix porn

<img
  class="absolute bottom-20 right-20 w-150"
  src="/images/lolcat-screenshot.png"
/>

---

# ttyd

- https://tsl0922.github.io/ttyd/

```bash
            _ ._  _ , _ ._
          (_ ' ( `  )_  .__)
        ( (  (    )   `)  ) _)
       (__ (_   (_ . _) _) ,__)
           `~~`\ ' . /`~~`
           ,::: ;   ; :::,
          ':::::::::::::::'
 ______________/_ __ \_____________
|                                  |
|               ttyd               |
| share your terminal over the web |
|__________________________________|
```

- category: network, dangerous

<!--
echo -e "ttyd\nshare your terminal over the web" | boxes -d nuke -a c
-->

---

# no-more-secrets <openmoji-unicorn style="display:inline"/>

when the tv team comes in your office

- <gh-stars count="5k"/> https://github.com/bartobri/no-more-secrets
- pipe something to `nms` or just run `sneakers`
- category: fun, unix porn


<Youtube id="F5bAa6gFvLs" />

<img
  class="absolute top-5 right-0 w-100"
  src="/images/nms.gif"
/>
<img
  class="absolute top-65 right-5 w-100"
  src="/images/nms-sneakers.gif"
/>

<!-- 
- video: from 0:35 to 0:45 ... 
- sneakers
- lc | nms
- lc | nms | lolcat
-->

---

# sl <openmoji-unicorn style="display:inline"/>

- <gh-stars count="3k"/> https://github.com/mtoyoda/sl
- typo `sl` (instead of `ls`) -> show steam locomotive
- can we pipe it to `lolcat`? of course
- category: fun, unix porn

<img
  class="absolute bottom-0 right-0 w-130"
  src="/images/sl-demo.gif"
/>

---

# gh

GitHub CLI

- <gh-stars count="32k"/> https://github.com/cli/cli
- create repos
- create PRs
- view issues
- ...

---

# thefuck <lightbulb/>

fix common typos / mistakes

- <gh-stars count="77k"/> https://github.com/nvbn/thefuck
- example: pushing a newly created git branch
- category: productivity

---

# patat

- <gh-stars count="2k"/> https://github.com/jaspervdj/patat
- nerdy slides in your shell
- runs in a terminal (similar to `reveal-js`/`sli.dev` for the browser)
- Pandoc syntax (f. ex. markdown)
- category: presentation, slides, unix porn

---

# ls on steroids

`ls` problem: **sort by name and time and size** at the same time...

**Use colors!**

- `colorls` ("the original" in ruby: https://github.com/athityakumar/colorls)
- `lsd` (in rust: https://github.com/Peltoche/lsd)
- `exa` (in rust: https://github.com/ogham/exa)

Required: font providing all symbols

- Example: NerdFonts https://github.com/ryanoasis/nerd-fonts

---

## colorls <lightbulb/>

- <gh-stars count="4k"/> https://github.com/athityakumar/colorls
- category: unix porn

<img
  class="absolute bottom-30 right-5 w-210"
  src="/images/colorls.png"
/>

---

## lsd

- <gh-stars count="9k"/> https://github.com/Peltoche/lsd
- alternative to `colorls`

---
layout: screencast
image: /screencasts/ncdu.gif
---

# ncdu <lightbulb/>

interactive `df` alternative

- https://dev.yorhel.nl/ncdu

---

# boxes <openmoji-unicorn style="display:inline"/>

- https://boxes.thomasjensen.com/docs/
- ascii art boxes
- show all templates: `boxes -l`
- category: unix porn

<!-- 
- echo "Hello World!" | boxes -d peek
- echo "Hello World!" | lolcat -f | boxes -d peek
-->

---

# monitoring

- htop
- apachetop
- ngxtop
- mtp
- pg_top
- powertop
- iotop
- iftop
- nethogs

<!-- 
- show top and htop
-->

---

# Resources

<div grid="~ cols-2 gap-4">
<div>

- <mdi-twitter class="inline"/> https://twitter.com/climagic
- <mdi-twitter class="inline"/> https://twitter.com/nixcraft
- <mdi-reddit class="inline"/> r/commandline
- <mdi-reddit class="inline"/> r/unixporn
- search for "**awesome-cli**"

</div>
<div>

<img
  class="absolute top-5 right-70 w-xs"
  src="/images/twitter-climagic.png"
/>
<img
  class="absolute bottom-10 right-25 w-xs"
  src="/images/twitter-nixcraft.png"
/>

</div>
</div>

---

# Slides

- https://github.com/MATHEMA-GmbH/2021-06-modern-linux-command-line-tools

---

# I forgot your favorite tool?

<div grid="~ cols-2 gap-4">
<div>

- jq (sed for json) https://stedolan.github.io/jq/
- mosh (robust replacement for ssh) https://mosh.org/
- fish_config (web-based configuration tool for fish shell) https://fishshell.com/docs/current/commands.html#fish_config
- xclip (cli to X clipboard) 403 stars https://github.com/astrand/xclip
- neofetch (fancy system info in the shell) 7.7k stars https://github.com/dylanaraps/neofetch 
- expect https://likegeeks.com/expect-command/
- httpie (cli http client) 45k stars https://httpie.org/
- http-prompt (cli http client) 7.6k stars http://http-prompt.com/
- pywal (color schemes for terminal) 3.4k stars https://github.com/dylanaraps/pywal

</div>
<div>

- apt-iselect (interactive ncurses package search for debian) https://www.rot13.org/~dpavlin/apt-iselect.html
- gcalcli (google calender in the shell) 2k stars https://github.com/insanum/gcalcli
- pastebinit (cli tool to send data to pastebin) 17 stars https://github.com/skorokithakis/pastebinit
- MapSCII (ascii google maps in the terminal) https://github.com/rastapasta/mapscii
- alwaysontop (always move prompt to top of screen) 160 stars https://github.com/swirepe/alwaysontop
- wttr.in (ascii weather report) https://github.com/chubin/wttr.in

</div>
</div>

<style>
li {
    font-size: 0.9rem
}
</style>
