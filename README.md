# (C# 코딩) File Compare Tool (파일 비교 툴)

## 개요
- 두 폴더의 파일들을 비교해서 상호 복사하는 툴

## 실행화면 (과제1)
- 코드의 실행 스크린샷과 구현 내용 설명

![실행화면](img/screenshot1-1.png)

![실행화면](img/screenshot1-2.png)

![실행화면](img/screenshot1-3.png)

![실행화면](img/screenshot1-4.png)

![실행화면](img/screenshot1-5.png)

- 구현한 내용 (위 그림 참조)
	- SplitContainer, Panel, Label, Button, TextBox, ListView 컨트롤을 사용하여 UI 구성
	- FolderBrowserDialog를 사용하여 폴더 선택 기능 구현
	- 컨트롤의 기본 기능 확인과 구현
	- Anchor 속성을 활용하여 Button과 TextBox, ListView의 위치 고정

## 실행화면 (과제2)
- 코드의 실행 스크린샷과 구현 내용 설명

![실행화면](img/screenshot2-1.png)

![실행화면](img/screenshot2-2.png)

![실행화면](img/screenshot2-3.png)

![실행화면](img/screenshot2-4.png)

![실행화면](img/screenshot2-5.png)

- 구현한 내용 (위 그림 참조)
	- 폴더 선택 기능과 파일 리스트 기능 구현(색상구분표시)
	- 1단계: 동일 파일 - 양쪽 모두 검은색
	- 2단계: 다른 파일 - New는 빨간색, Old는 회색
	- 3단계: 단독 파일 - 보라색