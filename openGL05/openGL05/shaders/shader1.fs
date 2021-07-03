#version 330 core
in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoords;

out vec4 FragColor;

struct SpotLight {
    vec3 position;
    vec3 direction;
    float cutOff;
    float outerCutOff;
    
    float constant;
    float linear;
    float quadratic;
    
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

uniform vec3 viewPos;
uniform SpotLight spotLight;
uniform sampler2D texture_diffuse1;
uniform sampler2D texture_specular1;
uniform sampler2D texture_normal1;
uniform float shininess;

uniform samplerCube skybox;

vec3 CalcSpotLight(SpotLight light, vec3 normal, vec3 fragPos, vec3 viewDir);

void main()
{
    /*
    vec3 norm = normalize(vec3(texture(texture_normal1, TexCoords)));
    vec3 viewDir = normalize(viewPos - FragPos);
    float intensity = 1.0f;
    FragColor = texture(texture_diffuse1, TexCoords) * intensity;
    FragColor += vec4( CalcSpotLight(spotLight, norm, FragPos, viewDir), 1.0f);
    */
    
    vec3 norm = normalize(vec3(texture(texture_normal1, TexCoords)));
    
    float ratio = 1.00 / 1.52;
    vec3 I = normalize(FragPos - viewPos);
    vec3 R = refract(I, normalize(Normal), ratio);
    FragColor = vec4(texture(skybox, R).rgb, 1.0);

}

// calculates the color when using a spot light.
vec3 CalcSpotLight(SpotLight light, vec3 normal, vec3 fragPos, vec3 viewDir)
{
    vec3 lightDir = normalize(light.position - fragPos);
    // diffuse shading
    float diff = max(dot(normal, lightDir), 0.0);
    // specular shading
    vec3 reflectDir = reflect(-lightDir, normal);
    float spec = pow(max(dot(viewDir, reflectDir), 0.0), shininess);
    // attenuation
    float distance = length(light.position - fragPos);
    float attenuation = 1.0 / (light.constant + light.linear * distance + light.quadratic * (distance * distance));
    // spotlight intensity
    float theta = dot(lightDir, normalize(-light.direction));
    float epsilon = light.cutOff - light.outerCutOff;
    float intensity = clamp((theta - light.outerCutOff) / epsilon, 0.0, 1.0);
    
    vec3 color;
    if(theta > light.cutOff)
    {
      // combine results
      vec3 ambient = light.ambient * vec3(texture(texture_diffuse1, TexCoords));
      vec3 diffuse = light.diffuse * diff * vec3(texture(texture_diffuse1, TexCoords));
      vec3 specular = light.specular * spec * vec3(texture(texture_specular1, TexCoords));
      /*
      ambient *= attenuation * intensity;
      diffuse *= attenuation * intensity;
      specular *= attenuation * intensity;
      */
      color = (ambient + diffuse + specular);
    }
    else  // 否则，使用环境光，让场景在聚光之外时不至于完全黑暗
      color = light.ambient * vec3(texture(texture_diffuse1, TexCoords));

    return color;
}
