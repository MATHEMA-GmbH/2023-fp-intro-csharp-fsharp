#!/bin/sh

# Invoke from this folder, otherwise change target location (`-o "..."`)
# Also adopt URL (last parameter)...

#qrencode -s 6 -l H -o "../public/images/slides-mddevdays.png" "https://draptik.github.io/2023-05-magdeburger-devdays-modern-linux-cli-tools"
#qrencode -s 6 -l H -o "./public/images/qr-code-dwx.png" "https://mathema-gmbh.github.io/2023-06-dwx-fp-csharp-to-fsharp"
qrencode -s 6 -l H -o "./public/images/qr-code-magdeburger-devdays-2024-draptik.png" "https://draptik.github.io/2024-05-md-dev-days-fp-intro-csharp-fsharp"
