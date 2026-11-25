shader_type canvas_item;
uniform float whiten : hint_range(0.0, 1.0) = 0.3;

void fragment() {
	vec4 c = texture(TEXTURE, UV);
	COLOR = vec4(mix(c.rgb, vec3(1.0), whiten), c.a);
}
