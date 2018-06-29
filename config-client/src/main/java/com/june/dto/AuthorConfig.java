package com.june.dto;

import org.springframework.boot.context.properties.ConfigurationProperties;
import org.springframework.stereotype.Component;

/**
 *  git 地址：https://gitee.com/zhongzunfa/spring-cloud-config/blob/master/V1-DEV/author.yml
 *  author.yml 49 Bytes →  zunfa.zhong zunfa.zhong 提交于 4月前 . 一个配置信息。

 spring.zzf:
    name: zzf
    age: 100
    sex: 1
 */
@Component
@ConfigurationProperties(prefix = "spring.zzf")
public class AuthorConfig {
    private String name;
    private Integer age;
    private Integer sex;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Integer getAge() {
        return age;
    }

    public void setAge(Integer age) {
        this.age = age;
    }

    public Integer getSex() {
        return sex;
    }

    public void setSex(Integer sex) {
        this.sex = sex;
    }

    @Override
    public String toString(){
        return "name:"+name+",age:"+age+",sex:"+sex;
    }
}
