# bs-config-code-converter
Converts BS config code to a config-utils header file

After starting the exe just copy pasta all your config creation code, and press enter until you see generated code. Then just put that into your header file.
**Note** that it has to be similar to the example below!
input: 
```cpp
    getConfig().config.AddMember("Rainbow", rapidjson::Value().SetBool(true), allocator);
    getConfig().config.AddMember("AlwaysRainbow", rapidjson::Value().SetBool(false), allocator);
    getConfig().config.AddMember("Fadeout", rapidjson::Value().SetBool(false), allocator);
    getConfig().config.AddMember("FullFade", rapidjson::Value().SetBool(false), allocator);
```

output:
```cpp
#pragma once
#include "extern/config-utils/shared/config-utils.hpp"

DECLARE_CONFIG(ModConfig,

    DECLARE_VALUE(Rainbow, bool, "Rainbow", true);
    DECLARE_VALUE(AlwaysRainbow, bool, "AlwaysRainbow", false);
    DECLARE_VALUE(Fadeout, bool, "Fadeout", false);
    DECLARE_VALUE(FullFade, bool, "FullFade", false);

    INIT_FUNCTION(
        INIT_VALUE(Rainbow);
        INIT_VALUE(AlwaysRainbow);
        INIT_VALUE(Fadeout);
        INIT_VALUE(FullFade);
    )
)
```
