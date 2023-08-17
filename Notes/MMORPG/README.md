---
layout: post
title: "Unity_MMORPG_Game"
---

# Unity_MMORPG_Game 제작 리뷰 입니다.

<div align="center">
  

![2023-06-01 01 12 27](https://github.com/Choi-Dong-Hyeon/Unity_MMORPG_Game/blob/main/2023-06-15%2020%2041%2027.png)

프로젝트창 에서 Scene파일 기준으로 위로는 Front단 영역 아래로는 Back단 영역으로 나누어 관리하기  쉽게 설계했습니다  

![2023-06-01 01 12 27](https://github.com/Choi-Dong-Hyeon/Unity_MMORPG_Game/blob/main/2023-06-07%2020%2014%2013.png)



---  

                                                                
 |    **[사용한 패턴]**     |  
 | :----------------------: |  
 | State, Lisner, Singlton  |  
 |  **[사용한 자료구조]**   |  
 | Stack, Dictionary, Array  

   
---  

[**기능 구현**]  


|                          **[이동]**                          |  
| :----------------------------------------------------------: |  
|    **레이캐스팅**과 마우스좌표를 이용하여 움직임을 구현.     |  
|                       **[애니메이션]**                       |  
|    상태패턴으로 관리하며 상태의조건을 상수enum으로 구현.     |  
|                          **[충돌]**                          |  
| 플레이어의 로컬좌표의 바라보는 방향으로 레이캐스팅하여 구현. |  
|                         **[카메라]**                         |  
| 상태패턴으로 조건을 상수enum으로 물체가 카메라를 가려 플레이어가 보이지 않을때 이동 구현. |  
  
