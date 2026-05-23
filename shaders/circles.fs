#version 330 core
out vec4 FragColor;

uniform sampler2D texture0;            // The input texture

void main()
{
    vec2 resolution = vec2(1280.0, 720.0);
    float segmentSize = 6.0;      // distance between circles
    float circle_radius = 3.2;     // radius of each circle

    vec2 uv = gl_FragCoord.xy / resolution;
    vec2 pixel = gl_FragCoord.xy;

    vec3 baseColor = texture(texture0, uv).rgb;

    // Find pixel position inside its current segment
    vec2 segment_based_coords = mod(pixel, segmentSize);

    // Compute distance from the center of the segment
    vec2 center = vec2(segmentSize * 0.5);
    float dis = length(segment_based_coords - center);

    // Circle mask
    float mask = smoothstep(circle_radius, circle_radius - 1.0, dis);

    // Mix black background with base color
    vec3 color = mix(vec3(0.0), baseColor, mask);

    FragColor = vec4(color, 1.0);
}
