float2 floorAll(float2 val, float by){
                val *= by;
                val = floor(val);
                val /= by;
                return val;
            }

float2 repeat(float2 val){
    return val - floor(val);
}