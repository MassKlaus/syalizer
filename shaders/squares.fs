#version 330 core
out vec4 FragColor;

uniform sampler2D texture0;            // The input texture

void main()
{
    vec2 resolution = vec2(1280.0, 720.0);
    float segmentSize = 5.0;

    // Normalized pixel coordinates (0..1)
    vec2 uv = gl_FragCoord.xy / resolution;

    // Pixel coordinates (0..width/height)
    vec2 pixel = gl_FragCoord.xy;

    // Sample the original color
    vec3 baseColor = texture(texture0, uv).rgb;

    // Determine which segment (integer index)
    ivec2 segment = ivec2(floor(pixel / segmentSize));

    // Alternate pattern:
    bool isOdd = ( (segment.x + segment.y) % 2 ) == 1;

    vec3 color = isOdd ? baseColor : vec3(0.0);

    FragColor = vec4(color, 1.0);
}
